using FarmManagement.Application.Features.SiteMasters.Commands.CreateSiteMaster;
using FarmManagement.Application.Features.SiteMasters.Commands.DeleteSiteMaster;
using FarmManagement.Application.Features.SiteMasters.Commands.UpdateSiteMaster;
using FarmManagement.Application.Features.SiteMasters.Queries.GetSiteMasterDetail;
using FarmManagement.Application.Features.SiteMasters.Queries.GetSiteMastersList;
using FarmManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagement.API.Controllers
{
    public class SiteMasterController : BaseController
    {
        private readonly IMediator _mediator;
        public SiteMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllSiteMasters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<SiteMasterListVm>>> GetAllSiteMasters()
        {
            var dtos = await _mediator.Send(new GetSiteMastersListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetSiteMasterById")]
        public async Task<ActionResult<SiteMasterDetailVm>> GetSiteMasterById(Guid id)
        {
            var getSiteMasterDetailQuery = new GetSiteMasterDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getSiteMasterDetailQuery));
        }

        [HttpPost(Name = "AddSiteMaster")]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateSiteMasterCommand createSiteMasterCommand)
        {
            var response = await _mediator.Send(createSiteMasterCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateSiteMaster")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateSiteMasterCommand updateSiteMasterCommand)
        {
            var response = await _mediator.Send(updateSiteMasterCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteSiteMaster")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteSiteMasterCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
