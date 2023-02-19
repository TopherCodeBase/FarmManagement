using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Application.Responses;
using FarmManagement.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.ItemMasters.Commands.UpdateItemMaster
{
    public class UpdateItemMasterCommandHandler : IRequestHandler<UpdateItemMasterCommand,BaseResponse>
    {
        private readonly IItemMasterRepository _itemMasterRepository;
        private readonly IMapper _mapper;
        public UpdateItemMasterCommandHandler(IItemMasterRepository itemMasterRepository, IMapper mapper)
        {
            _itemMasterRepository = itemMasterRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateItemMasterCommand request, CancellationToken cancellationToken)
        {
            var updateItemMasterCommandResponse = new BaseResponse();

            var itemMasterToUpdate = await _itemMasterRepository.GetByIdAsync(request.Id);

            if (itemMasterToUpdate == null)
            {
                throw new NotFoundException(nameof(ItemMaster), request.Id);
            }

            var validator = new UpdateItemMasterCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateItemMasterCommandResponse.Success = false;
                updateItemMasterCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateItemMasterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (updateItemMasterCommandResponse.Success)
            {
                _mapper.Map(request, itemMasterToUpdate, typeof(UpdateItemMasterCommand), typeof(ItemMaster));
                await _itemMasterRepository.UpdateAsync(itemMasterToUpdate);
            }

            return updateItemMasterCommandResponse;
        }
    }
}
