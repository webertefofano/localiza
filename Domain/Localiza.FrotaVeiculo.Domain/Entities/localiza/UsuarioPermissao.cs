using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class UsuarioPermissao : BaseEntity
    {
        public int IdUsuarioPermissao { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPermissao { get; set; }

        public virtual Permissao IdPermissaoNavigation { get; set; }
    }
}
