using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Commands.CreateMaterialMaster
{
    public class CreateMaterialMasterCommandValidator : AbstractValidator<CreateMaterialMasterCommand>
    {
        public CreateMaterialMasterCommandValidator()
        {
            RuleFor(x => x.SiteId).NotEmpty();
            RuleFor(x => x.ItemId).NotEmpty();
        }
    }
}
