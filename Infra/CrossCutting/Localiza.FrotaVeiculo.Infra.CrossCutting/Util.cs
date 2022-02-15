using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Infra.CrossCutting
{
    public static class Util
    {        
        #region jwt

        private static string GetClaim(int itemArray, IEnumerable<Claim> claims)
        {
            int i = 0;
            string retorno = null;
            
            foreach (Claim item in claims)
            {
                if (itemArray == i)
                {
                    retorno = item.Value.ToString();
                }

                i++;
            }

            return retorno;
        }

        public static string GetLoginUsuario(IEnumerable<Claim> claims)
        {
            string login = GetClaim(0, claims);
                        
            return login;
        }

        public static int GetIdUsuario(IEnumerable<Claim> claims)
        {
            int idUsuario;

            bool retorno = Int32.TryParse(GetClaim(1, claims), out idUsuario);

            if (retorno)
            {
                return idUsuario;
            }

            return 0;
        }

        public static string GetJwtKey()
        {
            return "Loc@liz@-357***935";
        }

        public static string GetJwtIssuer()
        {
            return "Loc@liz@.com";
        }

        public static string GetJwtAudience()
        {
            return "Loc@liz@";
        }

        public static int GetJwtExpireHour()
        {
            return 2;
        }

        #endregion
    }
}