using System;
using System.Collections.Generic;

#nullable disable

namespace Localiza.FrotaVeiculo.Domain.Entities.localiza
{
    public partial class Log
    {
        public int IdLog { get; set; }
        public Guid? Guid { get; set; }
        public string Mensagens { get; set; }
        public string Erro { get; set; }
        public int? StatusCode { get; set; }
    }
}
