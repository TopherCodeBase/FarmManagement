using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Cities.Queries.GetCitiesByProvince
{
    public class CityVm
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string ProvinceName { get; set; }
    }
}
