using FluentValidation;

namespace FarmManagement.Application.Features.ItemMasters.Commands.UpdateItemMaster
{
    public class UpdateItemMasterCommandValidator : AbstractValidator<UpdateItemMasterCommand>
    {
        public UpdateItemMasterCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ItemNo).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.UnitOfMeasure).NotEmpty();
        }
    }
}
