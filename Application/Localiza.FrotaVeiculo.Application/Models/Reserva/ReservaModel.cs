using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application.Models.Reserva
{
    public class ReservaModel
    {
        [SwaggerSchema(Description = "Id Cliente")]
        [Required]
        public int IdCliente { get; set; }
        [SwaggerSchema(Description = "Id Veículo")]
        public int IdVeiculo { get; set; }        
        [SwaggerSchema(Description = "Data Prevista Devolução Reserva")]
        public DateTimeOffset? DataPrevistaDevolucao { get; set; }        
    }

    public class UpdDataRetiradaDataDevolucaoModel
    {
        [SwaggerSchema(Description = "Id Reserva")]
        public int IdReserva { get; set; }
        [SwaggerSchema(Description = "Data Retirada Reserva")]
        public DateTimeOffset DataRetirada { get; set; }
        [SwaggerSchema(Description = "Data Prevista Devolução Reserva")]
        public DateTimeOffset? DataPrevistaDevolucao { get; set; }
    }

    public class UpdDataDevolucaoModel
    {
        [SwaggerSchema(Description = "Id Reserva")]
        public int IdReserva { get; set; }
        [SwaggerSchema(Description = "Data Devolução Reserva")]
        public DateTimeOffset? DataDevolucao { get; set; }
    }
}