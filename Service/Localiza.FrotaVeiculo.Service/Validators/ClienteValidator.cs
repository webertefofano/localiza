using FluentValidation;
using Localiza.FrotaVeiculo.Domain.Entities.localiza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.FrotaVeiculo.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator() 
        {
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Bairro obrigatório.")
                .NotNull().WithMessage("Bairro obrigatório.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Cidade obrigatória.")
                .NotNull().WithMessage("Cidade obrigatória.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("CPF obrigatório.")
                .NotNull().WithMessage("CPF obrigatório.");

            RuleFor(c => c.DataNacimento)
                .NotEmpty().WithMessage("Data Nascimento obrigatório.")
                .NotNull().WithMessage("Data Nascimento obrigatório.");

            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("Endereço obrigatório.")
                .NotNull().WithMessage("Endereço obrigatório.");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Estado obrigatório.")
                .Length(2).WithMessage("Sigla do Estado contém 2 caracteres.")
                .NotNull().WithMessage("Estado obrigatório.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome obrigatório.")
                .NotNull().WithMessage("Nome obrigatório.");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("Número obrigatório.")
                .NotNull().WithMessage("Número obrigatório.");

            RuleFor(c => c.NumeroCnh)
                .NotEmpty().WithMessage("CNH obrigatória.")
                .NotNull().WithMessage("CNH obrigatória.");            
        }
    }
}
