using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Infra.CrossCutting.Extensions
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private static ILogService _logService;


        protected static int getIdUsuario(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Util.GetIdUsuario(identity.Claims);
            }

            return 0;
        }

        protected static string getLogin(HttpContext context)
        {

            var identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return Util.GetLoginUsuario(identity.Claims);
            }

            return null;
        }
        
        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger, ILogService logService)
        {
            _logger = logger;
            _logService = logService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            LocalizaValidatorsResult result = new LocalizaValidatorsResult();
            List<string> mensagem = new List<string>();            
            mensagem.Add("Informe este código ao responsável pelo sistema");
            string error = exception.Message + (exception.InnerException != null ? " - " + exception.InnerException : string.Empty);
            result.Erro = error;
            result.Mensagens = mensagem;
            result.StatusCode = context.Response.StatusCode;

            //Grava o log
            Log log = new Log
            {
                Erro = result.Erro.Length > 400 ? result.Erro.Substring(0, 400) : result.Erro,
                Guid = result.CodigoRetorno,
                Mensagens = result.Mensagens.ToString().Length > 4000 ? result.Mensagens.ToString().Substring(0, 4000) : result.Erro,
                StatusCode = result.StatusCode
            };
            
            _logService.AddLog(log);
                        
            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}