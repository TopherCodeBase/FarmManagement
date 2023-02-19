using FarmManagement.Application.Responses;
using MediatR;

namespace FarmManagement.Application.Features.ItemMasters.Commands.UpdateItemMaster
{
    public class UpdateItemMasterCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public string ItemNo { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Category { get; set; }
    }
}
