using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Province.Queries.GetProvincesList
{
    public class GetProvincesListQuery : IRequest<List<ProvinceVm>>
    {
    }
}
