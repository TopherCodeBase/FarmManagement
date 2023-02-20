using FarmManagement.Application.Responses;
using MediatR;

namespace FarmManagement.Application.Features.Uoms.Commands.UpdateUom
{
    public class UpdateUomCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string? UnitOfMeasure { get; set; }
    }
}
