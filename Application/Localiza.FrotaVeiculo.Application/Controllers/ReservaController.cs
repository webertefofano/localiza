using Localiza.FrotaVeiculo.Application.Models;
using Localiza.FrotaVeiculo.Application.Models.Reserva;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Reserva")]
    public class ReservaController : ControllerBase
    {
        private IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpPost("AddReserva")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(Result))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult AddReserva(ReservaModel reservaModel)
        {            
            Result result = new Result();

            Reserva reserva = new Reserva
            {
                Data = System.DateTime.Now,                
                DataPrevistaDevolucao = reservaModel.DataPrevistaDevolucao,                
                IdCliente = reservaModel.IdCliente,
                IdVeiculo = reservaModel.IdVeiculo
            };

            int retorno = _reservaService.AddReserva(reserva);

            if (retorno == 0)
            {
                result.Status = "Não foi possível registrar a reserva.";
                result.HttpStatusCode = HttpStatusCode.NotFound;

                return new ObjectResult(result);
            }
            else if (retorno == -1)
            {
                result.Status = "Reserva indisponível para o Veículo, pois o mesmo não foi devolvido.";
                result.HttpStatusCode = HttpStatusCode.NotFound;

                return new ObjectResult(result);
            }
            
            result.Status = "Reserva registrada com sucesso.";
            result.HttpStatusCode = HttpStatusCode.Created;

            return new ObjectResult(result);
        }

        [HttpGet("ListaReservasDoCliente/{idCliente}")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(List<Reserva>))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult ListarReservasDoCliente(int idCliente)
        {
            Result result = new Result();

            List<Reserva> reservas = _reservaService.ListarReservas(idCliente);

            if (reservas == null)
            {
                return NotFound();
            }

            return Ok(reservas);
        }

        [HttpGet("ListaReservasPorDataRetirada/{dataInicio}/{dataFim}")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(List<Reserva>))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult ListarReservasPorDataRetirada(DateTime dataInicio, DateTime dataFim)
        {
            Result result = new Result();
         
            List<Reserva> reservas = _reservaService.ListarReservasPorDataRetirada(dataInicio, dataFim);

            if (reservas == null)
            {
                return NotFound();
            }

            return Ok(reservas);            
        }

        [HttpPatch("UpdDataRetiradaDataPrevista")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(Result))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult UpdDataRetiradaDataPrevista(UpdDataRetiradaDataDevolucaoModel updDataRetiradaDataDevolucaoModel)
        {
            Result result = new Result();

            _reservaService.UpdDataRetiradaDataPrevista(updDataRetiradaDataDevolucaoModel.IdReserva, updDataRetiradaDataDevolucaoModel.DataRetirada, updDataRetiradaDataDevolucaoModel.DataPrevistaDevolucao);

            result.Status = "Data Retira e/ou Data Devolução atualizada(s) com sucesso.";
            result.HttpStatusCode = HttpStatusCode.OK;

            return Ok(result);
        }

        [HttpPatch("UpdDataDevolucao")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(Result))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult UpdDataDevolucao(UpdDataDevolucaoModel updDataDevolucaoModel)
        {
            Result result = new Result();

            _reservaService.UpdDataDevolucao(updDataDevolucaoModel.IdReserva, updDataDevolucaoModel.DataDevolucao);

            result.Status = "Data Devolução atualizada com sucesso.";
            result.HttpStatusCode = HttpStatusCode.OK;

            return Ok(result);
        }

        [HttpGet("ListaPlacasVencidas")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(List<string>))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult ListaPlacasVencidas()
        {
            Result result = new Result();

            List<string> placas = _reservaService.ListaPlacasVencidas();

            if (placas == null)
            {
                return NotFound();
            }

            return Ok(placas);
        }
    }
}