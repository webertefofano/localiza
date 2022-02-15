using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application.Models.Cliente
{
    public class ClienteModel
    {
        [SwaggerSchema(Description = "Nome do Cliente")]
        public string Nome { get; set; }
        [SwaggerSchema(Description = "CPF")]
        public long Cpf { get; set; }
        [SwaggerSchema(Description = "Data Nascimento")]
        public DateTimeOffset DataNacimento { get; set; }
        [SwaggerSchema(Description = "Número CNH")]
        public long NumeroCnh { get; set; }
        [SwaggerSchema(Description = "Endereço")]
        public string Endereco { get; set; }
        [SwaggerSchema(Description = "Número")]
        public string Numero { get; set; }
        [SwaggerSchema(Description = "Bairro")]
        public string Bairro { get; set; }
        [SwaggerSchema(Description = "Cidade")]
        public string Cidade { get; set; }
        [SwaggerSchema(Description = "Sigla UF")]
        public string Estado { get; set; }
    }

    public class ClienteEnderecoModel
    {
        [SwaggerSchema(Description = "Id Cliente")]        
        public int IdCliente { get; set; }
        [SwaggerSchema(Description = "Endereço")]
        public string Endereco { get; set; }
        [SwaggerSchema(Description = "Número")]
        public string Numero { get; set; }
        [SwaggerSchema(Description = "Bairro")]
        public string Bairro { get; set; }
        [SwaggerSchema(Description = "Cidade")]
        public string Cidade { get; set; }
        [SwaggerSchema(Description = "Sigla UF")]
        public string Estado { get; set; }
    }
}