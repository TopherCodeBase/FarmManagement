using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.SiteMasters.Queries.GetSiteMastersList
{
    public class GetSiteMastersListQuery : IRequest<List<SiteMasterListVm>>
    {
    }
}
