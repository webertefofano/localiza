using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using Localiza.FrotaVeiculo.Domain.Interfaces;
using Localiza.FrotaVeiculo.Infra.Data.Context.Localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Service.Services
{
    public class AuthService : IAuthService
    {        
        private readonly ContextLocaliza _contextLocaliza;

        public AuthService(ContextLocaliza contextLocaliza)
        {
            _contextLocaliza = contextLocaliza;
        }
                
        public Usuario Login(string username, string password)
        {
            bool acesso = false;
            
            string senha = GetPasswordHash(password);

            Usuario user = new Usuario();

            user = _contextLocaliza.Usuarios.Where(x => x.Login == username && x.Password == senha).FirstOrDefault();

            if (user == null)
            {
                acesso = false;
            }
            else
            {
                acesso = true;
                //_usuarioAcesso.AddLogUsuarioAcesso(user.IdUsuario, user.Login, userFlagSucesso, userFlagBloqueado);
                _contextLocaliza.SaveChanges();
            }

            return (acesso ? user : null);
        }

        public List<Permissao> GetUsuarioPermissao(int idUsuario)
        {
            List<Permissao> permissoes = (from UP in _contextLocaliza.UsuarioPermissaos
                                          where UP.IdUsuario == idUsuario
                                          from P in _contextLocaliza.Permissaos.Where(p => p.IdPermissao == UP.IdPermissao)
                                          select P
                                          )
                                          .ToList();
            return permissoes;
        }

        public static string GetPasswordHash(string password)
        {
            string hash = string.Empty;

            MD5 md5Hash = MD5.Create();

            byte[] passwordEncrypted = md5Hash.ComputeHash(Encoding.Default.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder(hash.Length * 2);

            foreach (byte b in passwordEncrypted)
            {
                stringBuilder.Append(b.ToString("x2"));
            }

            hash = stringBuilder.ToString();

            return hash;
        }
    }
}