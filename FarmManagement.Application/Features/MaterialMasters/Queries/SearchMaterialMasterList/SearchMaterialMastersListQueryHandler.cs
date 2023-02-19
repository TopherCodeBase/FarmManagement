using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Queries.SearchMaterialMasterList
{
    public class SearchMaterialMastersListQueryHandler : IRequestHandler<SearchMaterialMastersListQuery, List<MaterialMasterListVm>>
    {
        private readonly IMaterialMasterRepository _materialMasterRepository;
        private readonly IMapper _mapper;
        public SearchMaterialMastersListQueryHandler(IMaterialMasterRepository materialMasterRepository, IMapper mapper)
        {
            _materialMasterRepository = materialMasterRepository;
            _mapper = mapper;
        }
        public async Task<List<MaterialMasterListVm>> Handle(SearchMaterialMastersListQuery request, CancellationToken cancellationToken)
        {
            var allMaterialMasters = await _materialMasterRepository.SearchAsync(request.Query,request.SiteId);
            return _mapper.Map<List<MaterialMasterListVm>>(allMaterialMasters);
        }
    }
}
