using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using MediatR;

namespace FarmManagement.Application.Features.SiteMasters.Queries.GetSiteMastersList
{
    public class GetSiteMastersListQueryHandler : IRequestHandler<GetSiteMastersListQuery, List<SiteMasterListVm>>
    {
        private readonly ISiteMasterRepository _siteMasterRepository;
        private readonly IMapper _mapper;

        public GetSiteMastersListQueryHandler(ISiteMasterRepository siteMasterRepository, IMapper mapper)
        {
            _siteMasterRepository = siteMasterRepository;
            _mapper = mapper;
        }
        public async Task<List<SiteMasterListVm>> Handle(GetSiteMastersListQuery request, CancellationToken cancellationToken)
        {
            var allSiteMasters = await _siteMasterRepository.ListAllAsync();
            return _mapper.Map<List<SiteMasterListVm>>(allSiteMasters);
        }
    }
}
