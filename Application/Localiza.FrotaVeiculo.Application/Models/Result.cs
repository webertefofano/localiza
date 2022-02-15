using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application.Models
{
    public class Result
    {
        public string Status { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
