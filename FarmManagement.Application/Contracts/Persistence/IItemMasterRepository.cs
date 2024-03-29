﻿using FarmManagement.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Contracts.Persistence
{
    public interface IItemMasterRepository : IBaseRepository<ItemMaster>
    {
        Task<bool> IsSiteExists(Guid Id);
    }
}
