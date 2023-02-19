using FarmManagement.Application.Contracts.Persistence;
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
        private readonly ISiteMasterRepository _siteMasterRepository;
        public CreateSiteMasterCommandValidator(ISiteMasterRepository siteMasterRepository)
        {
            _siteMasterRepository = siteMasterRepository;

            RuleFor(x => x.SiteName).NotEmpty();
            RuleFor(x => x.SiteCode).NotEmpty();

            // Site Code Unique constraint
            RuleFor(e => e)
                .MustAsync(SiteCodeUnique)
                .WithMessage("Site code already Exists!");

        }

        private async Task<bool> SiteCodeUnique(CreateSiteMasterCommand e, CancellationToken token)
        {
            return await _siteMasterRepository.IsSiteCodeUnique(e.SiteCode);
        }
    }
}
