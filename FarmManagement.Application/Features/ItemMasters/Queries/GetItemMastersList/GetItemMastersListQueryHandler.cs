using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.ItemMasters.Queries.GetItemMastersList
{
    public class GetItemMastersListQueryHandler : IRequestHandler<GetItemMastersListQuery, List<ItemMasterListVm>>
    {
        private readonly IItemMasterRepository _itemMasterRepository;
        private readonly IMapper _mapper;
        public GetItemMastersListQueryHandler(IItemMasterRepository itemMasterRepository, IMapper mapper)
        {
            _itemMasterRepository = itemMasterRepository;
            _mapper = mapper;
        }

        public async Task<List<ItemMasterListVm>> Handle(GetItemMastersListQuery request, CancellationToken cancellationToken)
        {
            var allItemMasters = await _itemMasterRepository.ListAllAsync();
            return _mapper.Map<List<ItemMasterListVm>>(allItemMasters);
        }
    }
}
