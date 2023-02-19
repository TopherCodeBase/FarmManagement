using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBConnection")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IItemMasterRepository, ItemMasterRepository>();
            services.AddScoped<IMaterialMasterRepository, MaterialMasterRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ISiteMasterRepository, SiteMasterRepository>();
            services.AddScoped<IUomRepository, UomRepository>();

            return services;
        }
    }
}
