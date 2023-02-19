using FarmManagement.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Contracts.Persistence
{
    public interface IMaterialMasterRepository : IBaseRepository<MaterialMaster>
    {
        Task<IReadOnlyList<MaterialMaster>> ListAllBySiteIdAsync(Guid siteId);
        Task<IReadOnlyList<MaterialMaster>> SearchAsync(string query, Guid siteId);
    }
}
