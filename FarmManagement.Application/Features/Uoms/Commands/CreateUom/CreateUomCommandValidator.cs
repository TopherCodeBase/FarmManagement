using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Commands.CreateUom
{
    public class CreateUomCommandValidator : AbstractValidator<CreateUomCommand>
    {
        public CreateUomCommandValidator()
        {
            RuleFor(x => x.UnitOfMeasure).NotEmpty();
            RuleFor(x => x.SiteId).NotEmpty();
        }
    }
}
