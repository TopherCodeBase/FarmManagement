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
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<City>> GetCityByProvince(string province)
        {
            return await _dbContext.Cities.Where(x => x.ProvinceName == province).ToListAsync();
        }
    }
}
