namespace FarmManagement.Application.Features.ItemMasters.Queries.GetItemMasterDetail
{
    public class ItemMasterDetailVm
    {
        public int Id { get; set; }
        public string? ItemNo { get; set; }
        public string? Description { get; set; }
        public string? UnitOfMeasure { get; set; }
        public string Category { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        //Relationships
        public Guid SiteId { get; set; }
        public string SiteName { get; set; }
    }
}
