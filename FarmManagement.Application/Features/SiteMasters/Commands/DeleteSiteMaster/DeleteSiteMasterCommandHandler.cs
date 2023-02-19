using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Features.SiteMasters.Commands.DeleteSiteMaster
{
    public class DeleteSiteMasterCommandHandler : IRequestHandler<DeleteSiteMasterCommand>
    {
        private readonly IBaseRepository<SiteMaster> _siteMasterRepository;
        public DeleteSiteMasterCommandHandler(IBaseRepository<SiteMaster> siteMasterRepository)
        {
            _siteMasterRepository = siteMasterRepository;
        }

        public async Task<Unit> Handle(DeleteSiteMasterCommand request, CancellationToken cancellationToken)
        {
            var siteMasterToDelete = await _siteMasterRepository.GetByIdAsync(request.Id);

            if(siteMasterToDelete == null)
            {
                throw new NotFoundException(nameof(SiteMaster),request.Id);
            }

            await _siteMasterRepository.DeleteAsync(siteMasterToDelete);

            return Unit.Value;
        }
    }
}
