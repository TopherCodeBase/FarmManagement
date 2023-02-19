using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Cities.Queries.GetCitiesByProvince
{
    public class GetCitiesByProvinceQuery : IRequest<List<CityVm>>
    {
        public string Province { get; set; }
    }
}
