using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Responses;
using FarmManagement.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Commands.CreateMaterialMaster
{
    public class CreateMaterialMasterCommandHandler : IRequestHandler<CreateMaterialMasterCommand, BaseResponse>
    {
        private readonly IMaterialMasterRepository _materialMasterRepository;
        private readonly IMapper _mapper;
        public CreateMaterialMasterCommandHandler(IMaterialMasterRepository materialMasterRepository, IMapper mapper)
        {
            _materialMasterRepository = materialMasterRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateMaterialMasterCommand request, CancellationToken cancellationToken)
        {
            var createMaterialMasterCommandResponse = new BaseResponse();

            var validator = new CreateMaterialMasterCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createMaterialMasterCommandResponse.Success = false;
                createMaterialMasterCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createMaterialMasterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createMaterialMasterCommandResponse.Success)
            {
                var materialMaster = _mapper.Map<MaterialMaster>(request);
                materialMaster = await _materialMasterRepository.AddAsync(materialMaster);
            }

            return createMaterialMasterCommandResponse;
        }
    }
}
