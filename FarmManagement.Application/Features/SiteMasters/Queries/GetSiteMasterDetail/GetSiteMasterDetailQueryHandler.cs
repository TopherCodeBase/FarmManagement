using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Domain.Entitites;
using MediatR;

namespace FarmManagement.Application.Features.SiteMasters.Queries.GetSiteMasterDetail
{
    public class GetSiteMasterDetailQueryHandler : IRequestHandler<GetSiteMasterDetailQuery, SiteMasterDetailVm>
    {
        private readonly ISiteMasterRepository _siteMasterRepository;
        private readonly IMapper _mapper;

        public GetSiteMasterDetailQueryHandler(ISiteMasterRepository siteMasterRepository, IMapper mapper)
        {
            _siteMasterRepository = siteMasterRepository;
            _mapper = mapper;
        }
        public async Task<SiteMasterDetailVm> Handle(GetSiteMasterDetailQuery request, CancellationToken cancellationToken)
        {
            var siteMaster = await _siteMasterRepository.GetByIdAsync(request.Id); ;

            if (siteMaster == null)
            {
                throw new NotFoundException(nameof(SiteMaster), request.Id);
            }

            var siteMasterDto = _mapper.Map<SiteMasterDetailVm>(siteMaster);

            return siteMasterDto;
        }
    }
}
