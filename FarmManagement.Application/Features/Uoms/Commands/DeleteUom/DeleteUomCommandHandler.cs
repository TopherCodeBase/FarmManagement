using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.Uoms.Commands.DeleteUom
{
    public class DeleteUomCommandHandler : IRequestHandler<DeleteUomCommand>
    {
        private readonly IUomRepository _uomRepository;
        public DeleteUomCommandHandler(IUomRepository uomRepository)
        {
            _uomRepository = uomRepository;
        }

        public async Task<Unit> Handle(DeleteUomCommand request, CancellationToken cancellationToken)
        {
            var uomToDelete = await _uomRepository.GetByIdAsync(request.Id);

            if (uomToDelete == null)
            {
                throw new NotFoundException(nameof(SiteMaster), request.Id);
            }

            await _uomRepository.DeleteAsync(uomToDelete);

            return Unit.Value;
        }
    }
}
