using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Service.Validators
{
    public class ReservaValidator : AbstractValidator<Reserva>
    {
        public ReservaValidator() 
        {                                    
            RuleFor(c => c.DataPrevistaDevolucao)
                .NotEmpty().WithMessage("Data Prevista Devolução obrigatória.")
                .NotNull().WithMessage("Data Prevista Devolução obrigatória.");

            RuleFor(c => c.IdCliente)
                .NotEmpty().WithMessage("Cliente obrigatório.")
                .NotNull().WithMessage("Cliente obrigatório.");

            RuleFor(c => c.IdVeiculo)
                .NotEmpty().WithMessage("Veículo obrigatório.")
                .NotNull().WithMessage("Veículo obrigatório.");

            RuleFor(c => c.DataDevolucao)
                .GreaterThan(c => c.DataRetirada)
                .WithMessage("A data de devolução não pode ser inferior a data de retirada do veículo.");
        }
    }
}
