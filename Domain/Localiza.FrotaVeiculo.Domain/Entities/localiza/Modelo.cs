using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class Modelo : BaseEntity
    {
        public Modelo()
        {
            Veiculos = new HashSet<Veiculo>();
        }

        public int IdModelo { get; set; }
        public string Nome { get; set; }
        public int? Peso { get; set; }
        public int IdFabricante { get; set; }

        public virtual Fabricante IdFabricanteNavigation { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
