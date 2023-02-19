using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.MaterialMasters.Commands.DeleteMaterialMaster
{
    public class DeleteMaterialMasterCommandHandler : IRequestHandler<DeleteMaterialMasterCommand>
    {
        private readonly IMaterialMasterRepository _materialMasterRepository;
        public DeleteMaterialMasterCommandHandler(IMaterialMasterRepository materialMasterRepository)
        {
            _materialMasterRepository = materialMasterRepository;
        }
        public async Task<Unit> Handle(DeleteMaterialMasterCommand request, CancellationToken cancellationToken)
        {
            var materialMasterToDelete = await _materialMasterRepository.GetByIdAsync(request.Id);

            if (materialMasterToDelete == null)
            {
                throw new NotFoundException(nameof(MaterialMaster), request.Id);
            }

            await _materialMasterRepository.DeleteAsync(materialMasterToDelete);

            return Unit.Value;
        }
    }
}
