using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Persistence.Repositories
{
    public class MaterialMasterRepository : BaseRepository<MaterialMaster> , IMaterialMasterRepository
    {
        public MaterialMasterRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyList<MaterialMaster>> ListAllBySiteIdAsync(Guid siteId)
        {
            return await this._dbContext.MaterialMasters.Include(x => x.SiteMaster)
                                                    .Include(x => x.ItemMaster)
                                                    .Where(x => x.SiteId == siteId)
                                                    .ToListAsync();
        }

        public async Task<IReadOnlyList<MaterialMaster>> SearchAsync(string query, Guid siteId)
        {
            return await this._dbContext.MaterialMasters.Include(x => x.SiteMaster)
                                                    .Include(x => x.ItemMaster)
                                                    .Where(x => (x.SiteMaster.SiteName.Contains(query) ||
                                                                x.ItemMaster.Description.Contains(query) ||
                                                                x.ItemMaster.ItemNo.Contains(query) ||
                                                                x.ItemMaster.ItemType.Contains(query) ||
                                                                x.SiteMaster.SiteCode.Contains(query)) &&
                                                                (siteId == Guid.Empty || x.SiteId == siteId)
                                                                )
                                                    .ToListAsync();
        }
    }
}
