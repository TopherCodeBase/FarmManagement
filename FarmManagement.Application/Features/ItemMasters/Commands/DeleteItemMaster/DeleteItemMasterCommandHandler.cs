using AutoMapper;
using FarmManagement.Application.Contracts.Persistence;
using FarmManagement.Application.Exceptions;
using FarmManagement.Domain.Entitites;
using MediatR;

namespace FarmManagement.Application.Features.ItemMasters.Commands.DeleteItemMaster
{
    public class DeleteItemMasterCommandHandler : IRequestHandler<DeleteItemMasterCommand>
    {
        private readonly IItemMasterRepository _itemMasterRepository;
        public DeleteItemMasterCommandHandler(IItemMasterRepository itemMasterRepository)
        {
            _itemMasterRepository = itemMasterRepository;
        }
        public async Task<Unit> Handle(DeleteItemMasterCommand request, CancellationToken cancellationToken)
        {
            var itemMasterToDelete = await _itemMasterRepository.GetByIdAsync(request.Id);

            if (itemMasterToDelete == null)
            {
                throw new NotFoundException(nameof(ItemMaster), request.Id);
            }

            await _itemMasterRepository.DeleteAsync(itemMasterToDelete);

            return Unit.Value;
        }
    }
}
