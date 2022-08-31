using Application.Features.Brands.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createdBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createdBrandCommand);
            return Created("", result);
        }
    }
}
