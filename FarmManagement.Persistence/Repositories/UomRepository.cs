using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Persistence.Repositories
{
    public class UomRepository : BaseRepository<UOM> , IUomRepository
    {
        public UomRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
