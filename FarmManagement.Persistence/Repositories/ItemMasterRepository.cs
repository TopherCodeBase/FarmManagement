using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Domain.Entitites;
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

    }
}
