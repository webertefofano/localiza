using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Service.Validators
{
    public class LocalizaValidatorsResult
    {
        Guid _codigoRetorno = Guid.NewGuid();

        public Guid CodigoRetorno
        {
            get
            {
                return _codigoRetorno;
            }
            set
            {
                _codigoRetorno = value;
            }
        }
        public List<string> Mensagens { get; set; }
        public string Erro { get; set; }
        public int StatusCode { get; set; }
    }

    public static class Validators<TEntity>
    {
        public static void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}