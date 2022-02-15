using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class Veiculo : BaseEntity
    {
        public Veiculo()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdVeiculo { get; set; }
        public string Placa { get; set; }
        public int IdModelo { get; set; }
        public int? AnoFabricacao { get; set; }
        public int? AnoModelo { get; set; }
        
        public virtual Modelo IdModeloNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
