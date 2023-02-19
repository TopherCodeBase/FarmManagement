using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Application.Responses;
using FarmManagement.Domain.Entitites;
using MediatR;

namespace FarmManagement.Application.Features.MaterialMasters.Commands.UpdateMaterialMaster
{
    public class UpdateMaterialMasterCommandHandler : IRequestHandler<UpdateMaterialMasterCommand, BaseResponse>
    {
        private readonly IMaterialMasterRepository _materialMasterRepository;
        private readonly IMapper _mapper;
        public UpdateMaterialMasterCommandHandler(IMaterialMasterRepository materialMasterRepository, IMapper mapper)
        {
            _materialMasterRepository = materialMasterRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateMaterialMasterCommand request, CancellationToken cancellationToken)
        {
            var updateMaterialMasterCommandResponse = new BaseResponse();

            var materialMasterToUpdate = await _materialMasterRepository.GetByIdAsync(request.Id);

            if (materialMasterToUpdate == null)
            {
                throw new NotFoundException(nameof(MaterialMaster), request.Id);
            }

            var validator = new UpdateMaterialMasterCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateMaterialMasterCommandResponse.Success = false;
                updateMaterialMasterCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateMaterialMasterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (updateMaterialMasterCommandResponse.Success)
            {
                _mapper.Map(request, materialMasterToUpdate, typeof(UpdateMaterialMasterCommand), typeof(MaterialMaster));
                await _materialMasterRepository.UpdateAsync(materialMasterToUpdate);
            }

            return updateMaterialMasterCommandResponse;
        }
    }
}
