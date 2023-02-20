using FarmManagement.Application.Features.Uoms.Queries.GetUomsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Queries.GetUomsBySite
{
    public class GetUomBySiteQuery : IRequest<List<UomListVm>>
    {
        public Guid SiteId { get; set; }
    }
}
