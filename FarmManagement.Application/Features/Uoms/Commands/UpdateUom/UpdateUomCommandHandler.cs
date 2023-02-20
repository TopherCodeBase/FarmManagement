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

namespace FarmManagement.Application.Features.Uoms.Commands.UpdateUom
{
    public class UpdateUomCommandHandler : IRequestHandler<UpdateUomCommand, BaseResponse>
    {
        private readonly IUomRepository _uomRepository;
        private readonly IMapper _mapper;
        public UpdateUomCommandHandler(IUomRepository uomRepository, IMapper mapper)
        {
            _uomRepository = uomRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateUomCommand request, CancellationToken cancellationToken)
        {
            var updateUomCommandResponse = new BaseResponse();

            var uomToUpdate = await _uomRepository.GetByIdAsync(request.Id);

            if (uomToUpdate == null)
            {
                throw new NotFoundException(nameof(UOM), request.Id);
            }

            var validator = new UpdateUomCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateUomCommandResponse.Success = false;
                updateUomCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateUomCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (updateUomCommandResponse.Success)
            {
                _mapper.Map(request, uomToUpdate, typeof(UpdateUomCommand), typeof(UOM));
                await _uomRepository.UpdateAsync(uomToUpdate);
            }

            return updateUomCommandResponse;
        }
    }
}
