using FarmManagement.Application.Features.Uoms.Commands.CreateUom;
using FarmManagement.Application.Features.Uoms.Commands.DeleteUom;
using FarmManagement.Application.Features.Uoms.Commands.UpdateUom;
using FarmManagement.Application.Features.Uoms.Queries.GetUomDetail;
using FarmManagement.Application.Features.Uoms.Queries.GetUomsBySite;
using FarmManagement.Application.Features.Uoms.Queries.GetUomsList;
using FarmManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagement.API.Controllers
{
    public class UomController : BaseController
    {
        private readonly IMediator _mediator;
        public UomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllUoms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<UomListVm>>> GetAllUoms()
        {
            var dtos = await _mediator.Send(new GetUomListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetUomById")]
        public async Task<ActionResult<UomDetailVm>> GetUomById(int id)
        {
            var getUomDetailQuery = new GetUomDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getUomDetailQuery));
        }

        [HttpPost(Name = "AddUom")]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateUomCommand createUomCommand)
        {
            var response = await _mediator.Send(createUomCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateUom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateUomCommand updateUomCommand)
        {
            var response = await _mediator.Send(updateUomCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteUom")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteUomCommand = new DeleteUomCommand() { Id = id };
            await _mediator.Send(deleteUomCommand);
            return NoContent();
        }
        [HttpGet("GetAllUomsBySite/{id}", Name = "GetAllUomsBySite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<UomListVm>>> GetAllUomsBySite(Guid id)
        {
            var GetUomListQuery = new GetUomBySiteQuery() { SiteId = id };
            var dtos = await _mediator.Send(GetUomListQuery);
            return Ok(dtos);
        }
    }
}
