using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class Fabricante : BaseEntity
    {
        public Fabricante()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int IdFabricante { get; set; }
        public string Nome { get; set; }
        public int? Peso { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
