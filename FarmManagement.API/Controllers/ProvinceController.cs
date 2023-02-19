using FarmManagement.Application.Features.Province.Queries.GetProvincesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagement.API.Controllers
{
    public class ProvinceController : BaseController
    {
        private readonly IMediator _mediator;
        public ProvinceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProvinceVm>>> Get()
        {
            var dtos = await _mediator.Send(new GetProvincesListQuery());
            return Ok(dtos);
        }
    }
}
