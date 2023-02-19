using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.SiteMasters.Queries.GetSiteMastersList
{
    public class SiteMasterListVm
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
    }
}
