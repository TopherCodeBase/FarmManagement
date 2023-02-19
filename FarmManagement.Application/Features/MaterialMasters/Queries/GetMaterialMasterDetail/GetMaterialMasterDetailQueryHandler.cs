using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Domain.Entitites;
using MediatR;

namespace FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterDetail
{
    public class GetMaterialMasterDetailQueryHandler : IRequestHandler<GetMaterialMasterDetailQuery, MaterialMasterDetailVm>
    {
        private readonly IMaterialMasterRepository _materialMasterRepository;
        private readonly IMapper _mapper;
        public GetMaterialMasterDetailQueryHandler(IMaterialMasterRepository materialMasterRepository, IMapper mapper)
        {
            _materialMasterRepository = materialMasterRepository;
            _mapper = mapper;
        }
        public async Task<MaterialMasterDetailVm> Handle(GetMaterialMasterDetailQuery request, CancellationToken cancellationToken)
        {
            var materialMaster = await _materialMasterRepository.GetByIdAsync(request.Id); ;

            if (materialMaster == null)
            {
                throw new NotFoundException(nameof(MaterialMaster), request.Id);
            }

            var materialMasterDto = _mapper.Map<MaterialMasterDetailVm>(materialMaster);

            return materialMasterDto;
        }
    }
}
