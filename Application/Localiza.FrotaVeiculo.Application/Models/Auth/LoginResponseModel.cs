using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application.Models.Auth
{
    public class LoginResponseModel
    {
        [Required]
        [Display(Name = "Usuário")]
        [SwaggerSchema(Description = "Usuário")]
        public string Login { get; set; }

        [Display(Name = "Token")]
        [SwaggerSchema(Description = "Token")]
        public string Token { get; set; }
        
        [Display(Name = "Id Usuário")]
        [SwaggerSchema(Description = "Id Usuário")]
        public int? idUsuario { get; set; }

        [Display(Name = "Expiração")]
        [SwaggerSchema(Description = "Expiração")]
        public DateTime Expiracao { get; set; }

        [Display(Name = "Permissões")]
        [SwaggerSchema(Description = "Permissões")]
        public string Permissoes { get; set; }
    }
}