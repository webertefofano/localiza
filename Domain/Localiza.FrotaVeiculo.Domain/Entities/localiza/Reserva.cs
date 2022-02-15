using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class Reserva : BaseEntity
    {
        public int IdReserva { get; set; }
        public DateTimeOffset Data { get; set; }
        public int IdCliente { get; set; }
        public int IdVeiculo { get; set; }
        public DateTimeOffset DataRetirada { get; set; }
        public DateTimeOffset? DataPrevistaDevolucao { get; set; }
        public DateTimeOffset? DataDevolucao { get; set; }
        public bool? VeiculoRetirado { get; set; }

        [JsonIgnore]
        public virtual Cliente IdClienteNavigation { get; set; }
        [JsonIgnore]
        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
