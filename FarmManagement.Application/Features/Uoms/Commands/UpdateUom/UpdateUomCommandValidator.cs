using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Commands.UpdateUom
{
    public class UpdateUomCommandValidator : AbstractValidator<UpdateUomCommand>
    {
        public UpdateUomCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UnitOfMeasure).NotEmpty();
        }
    }
}
