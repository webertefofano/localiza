using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Service.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator() 
        {
            RuleFor(c => c.AnoFabricacao)
                .NotEmpty().WithMessage("Ano Fabricação obrigatório.")
                .NotNull().WithMessage("Ano Fabricação obrigatório.");

            RuleFor(c => c.AnoModelo)
                .NotEmpty().WithMessage("Ano Modelo obrigatória.")
                .NotNull().WithMessage("Ano Modelo obrigatória.");

            RuleFor(c => c.IdModelo)
                .NotEmpty().WithMessage("Modelo obrigatório.")
                .NotNull().WithMessage("Modelo obrigatório.");

            RuleFor(c => c.Placa)
                .NotEmpty().WithMessage("Placa obrigatório.")
                .Length(7).WithMessage("Placa contém 7 caracters.")
                .NotNull().WithMessage("Placa obrigatório.");            
        }
    }
}
