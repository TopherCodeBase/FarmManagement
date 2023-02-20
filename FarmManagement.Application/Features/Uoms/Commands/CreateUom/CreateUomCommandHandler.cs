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

namespace FarmManagement.Application.Features.Uoms.Commands.CreateUom
{
    public class CreateUomCommandHandler : IRequestHandler<CreateUomCommand, BaseResponse>
    {
        private readonly IUomRepository _uomRepository;
        private readonly IMapper _mapper;
        public CreateUomCommandHandler(IUomRepository uomRepository,IMapper mapper)
        {
            _uomRepository = uomRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateUomCommand request, CancellationToken cancellationToken)
        {
            var createUomCommandResponse = new BaseResponse();

            var validator = new CreateUomCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createUomCommandResponse.Success = false;
                createUomCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createUomCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createUomCommandResponse.Success)
            {
                var uom = _mapper.Map<UOM>(request);
                uom = await _uomRepository.AddAsync(uom);
            }

            return createUomCommandResponse;
        }
    }
}
