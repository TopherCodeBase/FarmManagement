﻿
namespace FarmManagement.Domain.Entitites
{
    public class ItemMaster
    {
        public Guid Id { get; set; }
        public string? ItemNo { get; set; }
        public string? Description { get; set; }
        public string? ItemType { get; set; }
        public string? UnitOfMeasure { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? LastPurchasedDate { get; set; }
        public decimal LastPurchasedPrice { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        //Relationships
        public Guid SiteId { get; set; }
        public SiteMaster SiteMaster { get; set; } = default!;
        public ICollection<MaterialMaster> MaterialMasters { get; set; }
    }
}
