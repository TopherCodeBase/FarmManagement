using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Commands.UpdateMaterialMaster
{
    public class UpdateMaterialMasterCommandValidator : AbstractValidator<UpdateMaterialMasterCommand>
    {
        public UpdateMaterialMasterCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
