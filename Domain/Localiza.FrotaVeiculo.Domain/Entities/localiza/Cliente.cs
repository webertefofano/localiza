using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class Cliente : BaseEntity
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public DateTimeOffset DataNacimento { get; set; }
        public long NumeroCnh { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
