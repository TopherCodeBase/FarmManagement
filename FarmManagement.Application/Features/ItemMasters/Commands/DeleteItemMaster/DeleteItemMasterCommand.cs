using MediatR;

namespace FarmManagement.Application.Features.ItemMasters.Commands.DeleteItemMaster
{
    public class DeleteItemMasterCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
