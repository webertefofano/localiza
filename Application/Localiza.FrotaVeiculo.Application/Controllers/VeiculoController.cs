using Localiza.FrotaVeiculo.Application.Models;
using Localiza.FrotaVeiculo.Application.Models.Veiculo;
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
    [Route("api/v1/Veiculo")]
    public class VeiculoController : ControllerBase
    {
        private IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost("AdicionarVeiculo")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(Result))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult AdicionarVeiculo(VeiculoModel veiculoModel)
        {
            Result result = new Result();

            Veiculo veiculo = new Veiculo
            {
                AnoFabricacao = veiculoModel.AnoFabricacao,
                AnoModelo = veiculoModel.AnoModelo,
                IdModelo = veiculoModel.IdModelo,
                Placa = veiculoModel.Placa
            };

            _veiculoService.AddVeiculo(veiculo);

            result.Status = "Veículo cadastrado com sucesso.";
            result.HttpStatusCode = HttpStatusCode.Created;

            return new ObjectResult(result);
        }

        [HttpGet("BuscaVeiculoPelaPlaca/{placa}")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(Veiculo))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult BuscaVeiculoPelaPlaca(string placa)
        {
            Result result = new Result();

            Veiculo veiculo = _veiculoService.BuscaVeiculoPelaPlaca(placa);

            return Ok(veiculo);
        }
                
        [HttpGet("ListarVeiculos/{idModelo?}/{idFabricante?}")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(List<Veiculo>))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult ListarVeiculos([SwaggerParameter("0 - Todos", Required = true)] int idModelo, [SwaggerParameter("0 - Todos", Required = true)] int idFabricante)
        {
            Result result = new Result();

            List<Veiculo> veiculos = _veiculoService.ListarVeiculos(idModelo, idFabricante);

            return Ok(veiculos);
        }
    }
}