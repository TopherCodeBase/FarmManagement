using FarmManagement.Application.Responses;
using MediatR;

namespace FarmManagement.Application.Features.MaterialMasters.Commands.UpdateMaterialMaster
{
    public class UpdateMaterialMasterCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
