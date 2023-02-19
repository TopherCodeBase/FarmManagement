using FarmManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Commands.CreateMaterialMaster
{
    public class CreateMaterialMasterCommand : IRequest<BaseResponse>
    {
        public Guid SiteId { get; set; }
        public Guid ItemId { get; set; }
        public decimal Quantity { get; set; }
        public string? Reference { get; set; }
        public string? Notes { get; set; }
        public decimal PurchasedQuantity { get; set; }
        public decimal PurchasedPrice { get; set; }
        public string? Status { get; set; }
    }
}
