using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Infra.Data.Context.Localiza;
using Localiza.FrotaVeiculo.Service.Services;
using Localiza.FrotaVeiculo.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Service.Services
{
    public class LogService : ILogService
    {   
        private readonly ContextLocaliza _contextLocaliza;

        public LogService(ContextLocaliza contextLocaliza)
        {
            _contextLocaliza = contextLocaliza;
        }

        /// <summary>
        /// Insere Log.
        /// </summary>
        /// <param name="log"></param>        
        public async void AddLog(Log log)
        {       
            _contextLocaliza.Logs.Add(log);
            _contextLocaliza.SaveChanges();            
        }        
    }
}