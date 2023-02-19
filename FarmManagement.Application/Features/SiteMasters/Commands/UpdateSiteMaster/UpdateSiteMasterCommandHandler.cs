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

namespace FarmManagement.Application.Features.SiteMasters.Commands.UpdateSiteMaster
{
    public class UpdateSiteMasterCommandHandler : IRequestHandler<UpdateSiteMasterCommand,BaseResponse>
    {
        private readonly ISiteMasterRepository _siteMasterRepository;
        private readonly IMapper _mapper;
        public UpdateSiteMasterCommandHandler(ISiteMasterRepository siteMasterRepository, IMapper mapper)
        {
            _siteMasterRepository = siteMasterRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateSiteMasterCommand request, CancellationToken cancellationToken)
        {
            var updateSiteMasterCommandResponse = new BaseResponse();

            var siteMasterToUpdate = await _siteMasterRepository.GetByIdAsync(request.Id);

            if(siteMasterToUpdate == null)
            {
                throw new NotFoundException(nameof(SiteMaster), request.Id);
            }

            var validator = new UpdateSiteMasterCommandValidator(_siteMasterRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateSiteMasterCommandResponse.Success = false;
                updateSiteMasterCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateSiteMasterCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (updateSiteMasterCommandResponse.Success)
            {
                _mapper.Map(request, siteMasterToUpdate, typeof(UpdateSiteMasterCommand), typeof(SiteMaster));
                await _siteMasterRepository.UpdateAsync(siteMasterToUpdate);
            }

            return updateSiteMasterCommandResponse;
        }
    }
}
