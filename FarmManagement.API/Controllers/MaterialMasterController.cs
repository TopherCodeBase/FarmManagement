using FarmManagement.Application.Features.MaterialMasters.Commands.CreateMaterialMaster;
using FarmManagement.Application.Features.MaterialMasters.Commands.DeleteMaterialMaster;
using FarmManagement.Application.Features.MaterialMasters.Commands.UpdateMaterialMaster;
using FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterDetail;
using FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterList;
using FarmManagement.Application.Features.MaterialMasters.Queries.GetMaterialMasterListBySite;
using FarmManagement.Application.Features.MaterialMasters.Queries.SearchMaterialMasterList;
using FarmManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagement.API.Controllers
{
    public class MaterialMasterController : BaseController
    {
        private readonly IMediator _mediator;
        public MaterialMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllMaterialMasters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MaterialMasterListVm>>> GetAllMaterialMasters()
        {
            var dtos = await _mediator.Send(new GetMaterialMastersListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetMaterialMasterById")]
        public async Task<ActionResult<MaterialMasterDetailVm>> GetMaterialMasterById(Guid id)
        {
            var getMaterialMasterDetailQuery = new GetMaterialMasterDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getMaterialMasterDetailQuery));
        }

        [HttpPost(Name = "AddMaterialMaster")]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateMaterialMasterCommand createMaterialMasterCommand)
        {
            var response = await _mediator.Send(createMaterialMasterCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateMaterialMaster")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse>> Update([FromBody] UpdateMaterialMasterCommand updateMaterialMasterCommand)
        {
            var response = await _mediator.Send(updateMaterialMasterCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteMaterialMaster")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteMaterialMasterCommand() { Id = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }

        [HttpGet("GetAllMaterialMastersBySite/{id}",Name = "GetAllMaterialMastersBySite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MaterialMasterListVm>>> GetAllMaterialMastersBySite(Guid id)
        {
            var getMaterialMastersListBySiteQuery = new GetMaterialMastersListBySiteQuery() { SiteId = id };
            var dtos = await _mediator.Send(getMaterialMastersListBySiteQuery);
            return Ok(dtos);
        }

        [HttpGet("SearchMaterialMasterList/{query}/{siteId?}",Name = "SearchMaterialMasterList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<MaterialMasterListVm>>> SearchMaterialMasterList(string query, Guid siteId = default(Guid))
        {
            var searchMaterialMastersListQuery = new SearchMaterialMastersListQuery() { Query = query , SiteId = siteId };
            var dtos = await _mediator.Send(searchMaterialMastersListQuery);
            return Ok(dtos);
        }
    }
}
