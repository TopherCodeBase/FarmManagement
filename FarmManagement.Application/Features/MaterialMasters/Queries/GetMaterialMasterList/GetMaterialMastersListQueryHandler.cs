using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterList
{
    public class GetMaterialMastersListQueryHandler : IRequestHandler<GetMaterialMastersListQuery, List<MaterialMasterListVm>>
    {
        private readonly IMaterialMasterRepository _materialMasterRepository;
        private readonly IMapper _mapper;
        public GetMaterialMastersListQueryHandler(IMaterialMasterRepository materialMasterRepository, IMapper mapper)
        {
            _materialMasterRepository = materialMasterRepository;
            _mapper = mapper;
        }
        public async Task<List<MaterialMasterListVm>> Handle(GetMaterialMastersListQuery request, CancellationToken cancellationToken)
        {
            var allMaterialMasters = await _materialMasterRepository.ListAllAsync();
            return _mapper.Map<List<MaterialMasterListVm>>(allMaterialMasters);
        }
    }
}
