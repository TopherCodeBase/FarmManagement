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
    public class ItemMasterRepository : BaseRepository<ItemMaster>, IItemMasterRepository
    {
        public ItemMasterRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public override async Task<ItemMaster?> GetByIdAsync(Guid id)
        {
            var itemMaster = await this._dbContext.ItemMasters.Include(x => x.SiteMaster).Where(x => x.Id == id).FirstOrDefaultAsync();
            return itemMaster;
        }

        public Task<bool> IsSiteExists(Guid id)
        {
            var result = _dbContext.SiteMasters.Any(x => x.Id == id);
            return Task.FromResult(result);
        }

        public override async Task<IReadOnlyList<ItemMaster>> ListAllAsync()
        {
            return await this._dbContext.ItemMasters.Include(x => x.SiteMaster).ToListAsync();
        }
    }
}
