using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Domain.Interfaces
{
    public interface IAuthService
    {
        Usuario Login(string username, string password);

        List<Permissao> GetUsuarioPermissao(int idUsuario);
    }
}
