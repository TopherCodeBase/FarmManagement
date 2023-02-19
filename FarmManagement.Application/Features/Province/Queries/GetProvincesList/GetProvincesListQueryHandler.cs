using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Province.Queries.GetProvincesList
{
    public class GetProvincesListQueryHandler : IRequestHandler<GetProvincesListQuery, List<ProvinceVm>>
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;
        public GetProvincesListQueryHandler(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }
        public async Task<List<ProvinceVm>> Handle(GetProvincesListQuery request, CancellationToken cancellationToken)
        {
            var provinces = await _provinceRepository.ListAllAsync();
            return _mapper.Map<List<ProvinceVm>>(provinces);
        }
    }
}
