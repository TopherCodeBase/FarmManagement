using FarmManagement.Application.Features.ItemMasters.Commands.CreateItemMaster;
using FarmManagement.Application.Features.ItemMasters.Commands.DeleteItemMaster;
using FarmManagement.Application.Features.ItemMasters.Commands.UpdateItemMaster;
using FarmManagement.Application.Features.ItemMasters.Queries.GetItemMasterDetail;
using FarmManagement.Application.Features.ItemMasters.Queries.GetItemMastersList;
using FarmManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagement.API.Controllers
{
    public class ItemMasterController : BaseController
    {
        private readonly IMediator _mediator;
        public ItemMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllItemMasters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ItemMasterListVm>>> GetAllItemMasters()
        {
            var dtos = await _mediator.Send(new GetItemMastersListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetItemMasterById")]
        public async Task<ActionResult<ItemMasterDetailVm>> GetItemMasterById(Guid id)
        {
            var getItemMasterDetailQuery = new GetItemMasterDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getItemMasterDetailQuery));
        }

        [HttpPost(Name = "AddItemMaster")]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateItemMasterCommand createItemMasterCommand)
        {
            var response = await _mediator.Send(createItemMasterCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateItemMaster")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateItemMasterCommand updateItemMasterCommand)
        {
            var response = await _mediator.Send(updateItemMasterCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteItemMaster")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteItemMasterCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
