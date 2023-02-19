using FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterListBySite
{
    public class GetMaterialMastersListBySiteQuery : IRequest<List<MaterialMasterListVm>>
    {
        public Guid SiteId { get; set; }
    }
}
