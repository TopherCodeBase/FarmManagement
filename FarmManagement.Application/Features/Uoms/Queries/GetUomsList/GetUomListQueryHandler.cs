using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using MediatR;

namespace FarmManagement.Application.Features.Uoms.Queries.GetUomsList
{
    public class GetUomListQueryHandler : IRequestHandler<GetUomListQuery, List<UomListVm>>
    {
        private readonly IUomRepository _uomRepository;
        private readonly IMapper _mapper;
        public GetUomListQueryHandler(IUomRepository uomRepository, IMapper mapper)
        {
            _uomRepository = uomRepository;
            _mapper = mapper;
        }
        public async Task<List<UomListVm>> Handle(GetUomListQuery request, CancellationToken cancellationToken)
        {
            var allUoms = await _uomRepository.ListAllAsync();
            return _mapper.Map<List<UomListVm>>(allUoms);
        }
    }
}
