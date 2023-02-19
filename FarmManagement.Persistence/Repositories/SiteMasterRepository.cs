using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Persistence.Repositories
{
    public class SiteMasterRepository : BaseRepository<SiteMaster> , ISiteMasterRepository
    {
        public SiteMasterRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> IsSiteCodeUnique(string siteCode)
        {
            var result = !_dbContext.SiteMasters.Any(x => x.SiteCode == siteCode);
            return Task.FromResult(result);
        }
    }
}
