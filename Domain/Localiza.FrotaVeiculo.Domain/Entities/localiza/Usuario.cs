using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class Usuario : BaseEntity
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
