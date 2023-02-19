using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Cities.Queries.GetCitiesByProvince
{
    public class GetCitiesByProvinceQueryHandler : IRequestHandler<GetCitiesByProvinceQuery, List<CityVm>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public GetCitiesByProvinceQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<List<CityVm>> Handle(GetCitiesByProvinceQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetCityByProvince(request.Province);
            return _mapper.Map<List<CityVm>>(cities);
        }
    }
}
