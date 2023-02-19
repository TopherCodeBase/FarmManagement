using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterList
{
    public class GetMaterialMastersListQuery : IRequest<List<MaterialMasterListVm>>
    {
    }
}
