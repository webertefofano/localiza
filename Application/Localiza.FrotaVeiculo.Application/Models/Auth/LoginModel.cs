using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Application.Models.Auth
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Usuário")]
        [SwaggerSchema(Description ="Usuário")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [SwaggerSchema(Description = "Senha")]
        public string Password { get; set; }        
    }
}
