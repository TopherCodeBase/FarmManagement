using FarmManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Commands.CreateUom
{
    public class CreateUomCommand : IRequest<BaseResponse>
    {
        public string? UnitOfMeasure { get; set; }
        public Guid SiteId { get; set; }
    }
}
