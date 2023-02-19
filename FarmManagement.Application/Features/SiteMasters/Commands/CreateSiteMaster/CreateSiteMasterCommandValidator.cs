using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.SiteMasters.Commands.CreateSiteMaster
{
    public class CreateSiteMasterCommandValidator : AbstractValidator<CreateSiteMasterCommand>
    {
        public CreateSiteMasterCommandValidator()
        {
            RuleFor(x => x.SiteName).NotEmpty();
        }
    }
}
