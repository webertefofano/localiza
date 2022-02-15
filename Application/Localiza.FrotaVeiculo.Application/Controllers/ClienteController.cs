using Localiza.FrotaVeiculo.Application.Models;
using Localiza.FrotaVeiculo.Application.Models.Cliente;
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
    [Route("api/v1/Cliente")]
    public class ClienteController : ControllerBase
    {
        private IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("AddCliente")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(Result))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult AddCliente(ClienteModel clienteModel)
        {
            Result result = new Result();

            Cliente cliente = new Cliente
            {
                Bairro = clienteModel.Bairro,
                Cidade = clienteModel.Cidade,
                Cpf = clienteModel.Cpf,
                DataNacimento = clienteModel.DataNacimento,
                Endereco = clienteModel.Endereco,
                Estado = clienteModel.Estado,
                Nome = clienteModel.Nome,
                Numero = clienteModel.Numero,
                NumeroCnh = clienteModel.NumeroCnh
            };

            _clienteService.AddCliente(cliente);

            result.Status = "Cliente cadastrado com sucesso.";
            result.HttpStatusCode = HttpStatusCode.Created;

            return new ObjectResult(result);
        }

        [HttpGet("ListarClientes/{cpf?}/{nome?}")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(List<Cliente>))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult ListarClientes([SwaggerParameter("0 - Ignora o CPF e busca pelo nome", Required = true)] long cpf, string nome)
        {
            List<Cliente> clientes = _clienteService.ListarClientes(cpf, nome);

            Response.StatusCode = 200;
            
            return new ObjectResult(clientes);
        }

        [HttpPatch("UpdEnderecoCliente")]
        [SwaggerResponse(((int)HttpStatusCode.OK), Type = typeof(string))]
        [SwaggerResponse(((int)HttpStatusCode.BadRequest), Type = typeof(LocalizaValidatorsResult))]
        public IActionResult UpdEnderecoCliente(ClienteEnderecoModel clienteEnderecoModel)
        {
            _clienteService.UpdEnderecoCliente(clienteEnderecoModel.IdCliente, clienteEnderecoModel.Endereco,
                clienteEnderecoModel.Numero, clienteEnderecoModel.Bairro, clienteEnderecoModel.Cidade, clienteEnderecoModel.Estado);

            Response.StatusCode = 200;

            return new ObjectResult("Endereço do Cliente atualizado com sucesso.");
        }
    }
}