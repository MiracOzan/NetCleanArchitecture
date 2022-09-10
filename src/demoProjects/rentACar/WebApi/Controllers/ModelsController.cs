using Application.Features.Models.Models;
using Application.Features.Models.Queries;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuerry getListModelsQuerry = new(){PageRequest = pageRequest};
            ModelListModel result = await Mediator?.Send(getListModelsQuerry);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListModelByDynamicQuerry getListModelsByDynamicQuerry = new(){PageRequest = pageRequest};
            ModelListModel result = await Mediator?.Send(getListModelsByDynamicQuerry);
            return Ok(result);
        }
    }
}
