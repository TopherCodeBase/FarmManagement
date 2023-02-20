using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Queries.GetUomsList
{
    public class GetUomListQuery : IRequest<List<UomListVm>>
    {

    }
}
