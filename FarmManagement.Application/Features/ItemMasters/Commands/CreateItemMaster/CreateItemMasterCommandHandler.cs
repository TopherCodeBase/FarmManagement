using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Responses;
using FarmManagement.Domain.Entitites;
using MediatR;

namespace FarmManagement.Application.Features.ItemMasters.Commands.CreateItemMaster
{
    public class CreateItemMasterCommandHandler : IRequestHandler<CreateItemMasterCommand, BaseResponse>
    {
        private readonly IItemMasterRepository _itemMasterRepository;
        private readonly IMapper _mapper;
        public CreateItemMasterCommandHandler(IItemMasterRepository itemMasterRepository, IMapper mapper)
        {
            _itemMasterRepository = itemMasterRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateItemMasterCommand request, CancellationToken cancellationToken)
        {
            var createItemMasterCommandResponse = new BaseResponse();

            var validator = new CreateItemMasterCommandValidator(_itemMasterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createItemMasterCommandResponse.Success = false;
                createItemMasterCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createItemMasterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createItemMasterCommandResponse.Success)
            {
                var itemMaster = _mapper.Map<ItemMaster>(request);
                itemMaster = await _itemMasterRepository.AddAsync(itemMaster);
            }

            return createItemMasterCommandResponse;
        }
    }
}
