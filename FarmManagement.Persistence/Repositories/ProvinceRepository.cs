using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Persistence.Repositories
{
    public class ProvinceRepository : BaseRepository<Province> , IProvinceRepository
    {
        public ProvinceRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
