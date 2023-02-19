using FarmManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.ItemMasters.Commands.CreateItemMaster
{
    public class CreateItemMasterCommand : IRequest<BaseResponse>
    {
        public Guid SiteId { get; set; }
        public string? ItemNo { get; set; }
        public string? Description { get; set; }
        public string? ItemType { get; set; }
        public string? UnitOfMeasure { get; set; }
    }
}
