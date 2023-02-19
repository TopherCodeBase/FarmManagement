using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.ItemMasters.Queries.GetItemMasterDetail
{
    public class GetItemMasterDetailQueryHandler : IRequestHandler<GetItemMasterDetailQuery, ItemMasterDetailVm>
    {
        private readonly IItemMasterRepository _itemMasterRepository;
        private readonly IMapper _mapper;
        
        public GetItemMasterDetailQueryHandler(IItemMasterRepository itemMasterRepository,IMapper mapper)
        {
            _itemMasterRepository = itemMasterRepository;
            _mapper = mapper;
        }

        public async Task<ItemMasterDetailVm> Handle(GetItemMasterDetailQuery request, CancellationToken cancellationToken)
        {
            var itemMaster = await _itemMasterRepository.GetByIdAsync(request.Id); ;
            
            if (itemMaster == null)
            {
                throw new NotFoundException(nameof(ItemMaster), request.Id);
            }

            var itemMasterDto = _mapper.Map<ItemMasterDetailVm>(itemMaster);

            return itemMasterDto;
        }
    }
}
