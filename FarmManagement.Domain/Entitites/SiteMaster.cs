
namespace FarmManagement.Domain.Entitites
{
    public class SiteMaster
    {
        public Guid Id { get; set; }
        public string? SiteCode { get; set; }
        public string? SiteName { get; set; }        
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Zip { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ParentSiteId { get; set; }
        public string? Status { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        //Relationships
        public ICollection<ItemMaster> ItemMasters { get; set; }
        public ICollection<MaterialMaster> MaterialMasters { get; set; }
        public ICollection<UOM> UOMs { get; set; }
    }
}
