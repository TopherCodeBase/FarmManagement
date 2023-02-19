using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterDetail
{
    public class MaterialMasterDetailVm
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public string? Reference { get; set; }
        public string? Notes { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public decimal PurchasedQuantity { get; set; }
        public decimal PurchasedPrice { get; set; }
        public Guid AccountId { get; set; }
        public string? Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public Guid SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }

        public Guid ItemId { get; set; }
        public string ItemDescription { get; set; }
        public string ItemNo { get; set; }
        public string ItemType { get; set; }
        public string ItemUnitOfMeasure { get; set; }
    }
}
