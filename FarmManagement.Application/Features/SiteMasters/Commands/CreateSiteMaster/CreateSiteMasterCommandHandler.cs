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

namespace FarmManagement.Application.Features.SiteMasters.Commands.CreateSiteMaster
{
    public class CreateSiteMasterCommandHandler : IRequestHandler<CreateSiteMasterCommand,BaseResponse>
    {
        private readonly ISiteMasterRepository _siteMasterRepository;
        private readonly IMapper _mapper;
        public CreateSiteMasterCommandHandler(ISiteMasterRepository siteMasterRepository,IMapper mapper)
        {
            _siteMasterRepository = siteMasterRepository;
            _mapper = mapper;   
        }

        public async Task<BaseResponse> Handle(CreateSiteMasterCommand request, CancellationToken cancellationToken)
        {
            var createSiteMasterCommandResponse = new BaseResponse();

            var validator = new CreateSiteMasterCommandValidator(_siteMasterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                createSiteMasterCommandResponse.Success = false;
                createSiteMasterCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createSiteMasterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createSiteMasterCommandResponse.Success)
            {
                var siteMaster = _mapper.Map<SiteMaster>(request);
                siteMaster = await _siteMasterRepository.AddAsync(siteMaster);
            }

            return createSiteMasterCommandResponse;
        }
    }
}
