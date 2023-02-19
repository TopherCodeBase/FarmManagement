using FarmManagement.Application.Features.Cities.Queries.GetCitiesByProvince;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmManagement.API.Controllers
{
    public class CityController : BaseController
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{province}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CityVm>>> Get(string province)
        {
            var getCitiesByProvinceQuery = new GetCitiesByProvinceQuery() { Province = province };

            var dtos = await _mediator.Send(getCitiesByProvinceQuery);
            return Ok(dtos);
        }
    }
}
