using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Domain.Entitites;
using MediatR;

namespace FarmManagement.Application.Features.Uoms.Queries.GetUomDetail
{
    public class GetUomDetailQueryHandler : IRequestHandler<GetUomDetailQuery, UomDetailVm>
    {
        private readonly IUomRepository _uomRepository;
        private readonly IMapper _mapper;
        public GetUomDetailQueryHandler(IUomRepository uomRepository, IMapper mapper)
        {
            _uomRepository = uomRepository;
            _mapper = mapper;
        }
        public async Task<UomDetailVm> Handle(GetUomDetailQuery request, CancellationToken cancellationToken)
        {
            var uom = await _uomRepository.GetByIdAsync(request.Id); ;

            if (uom == null)
            {
                throw new NotFoundException(nameof(UOM), request.Id);
            }

            var uomDto = _mapper.Map<UomDetailVm>(uom);

            return uomDto;
        }
    }
}
