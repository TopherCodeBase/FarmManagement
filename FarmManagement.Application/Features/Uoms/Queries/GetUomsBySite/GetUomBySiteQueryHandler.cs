using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Features.Uoms.Queries.GetUomsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Queries.GetUomsBySite
{
    public class GetUomBySiteQueryHandler : IRequestHandler<GetUomBySiteQuery, List<UomListVm>>
    {
        private readonly IUomRepository _uomRepository;
        private readonly IMapper _mapper;
        public GetUomBySiteQueryHandler(IUomRepository uomRepository, IMapper mapper)
        {
            _uomRepository = uomRepository;
            _mapper = mapper;
        }
        public async Task<List<UomListVm>> Handle(GetUomBySiteQuery request, CancellationToken cancellationToken)
        {
            var allUoms = await _uomRepository.ListAllBySiteAsync(request.SiteId);
            return _mapper.Map<List<UomListVm>>(allUoms);
        }
    }
}
