using Estapar.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estapar.Service.Validators
{
    public class VeiculoManobraValidator : AbstractValidator<VeiculoManobra>
    {
        public VeiculoManobraValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.DataHoraManobra)
                .NotEmpty().WithMessage("Is necessary to inform the CPF.")
                .NotNull().WithMessage("Is necessary to inform the CPF.");

        }
    }
}
