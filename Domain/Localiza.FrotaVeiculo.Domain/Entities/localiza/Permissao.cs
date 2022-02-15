using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class Permissao : BaseEntity
    {
        public Permissao()
        {
            UsuarioPermissaos = new HashSet<UsuarioPermissao>();
        }

        public int IdPermissao { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<UsuarioPermissao> UsuarioPermissaos { get; set; }
    }
}
