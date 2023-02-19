using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.SiteMasters.Commands.UpdateSiteMaster
{
    public class UpdateSiteMasterCommandValidator : AbstractValidator<UpdateSiteMasterCommand>
    {
        public UpdateSiteMasterCommandValidator()
        {
            RuleFor(x => x.SiteName).NotEmpty();
        }
    }
}
