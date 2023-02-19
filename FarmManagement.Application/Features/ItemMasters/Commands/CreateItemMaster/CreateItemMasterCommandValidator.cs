using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Domain.Entitites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.ItemMasters.Commands.CreateItemMaster
{
    public class CreateItemMasterCommandValidator : AbstractValidator<CreateItemMasterCommand>
    {
        private readonly IItemMasterRepository _itemMasterRepository;
        public CreateItemMasterCommandValidator(IItemMasterRepository itemMasterRepository)
        {
            _itemMasterRepository = itemMasterRepository;

            RuleFor(x => x.SiteId).NotEmpty();
            RuleFor(x => x.ItemNo).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.UnitOfMeasure).NotEmpty();

            RuleFor(e => e)
                .MustAsync(SiteExists)
                .WithMessage("Site Master Does not Exists");
        }
        private async Task<bool> SiteExists(CreateItemMasterCommand e, CancellationToken token)
        {
            return (await _itemMasterRepository.IsSiteExists(e.SiteId));
        }
    }
}
