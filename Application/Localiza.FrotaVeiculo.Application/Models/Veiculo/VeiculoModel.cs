using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application.Models.Veiculo
{
    public class VeiculoModel
    {
        [SwaggerSchema(Description = "Placa")]
        public string Placa { get; set; }
        [SwaggerSchema(Description = "Id Modelo")]
        public int IdModelo { get; set; }
        [SwaggerSchema(Description = "Ano de Fabricação")]
        public int? AnoFabricacao { get; set; }
        [SwaggerSchema(Description = "Ano do Modelo")]
        public int? AnoModelo { get; set; }
    }
}
