using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries;
using Application.Features.Brands.Queries.GetByIdBrands;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createdBrandCommand)
        {
            CreatedBrandDto result = await Mediator.Send(createdBrandCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandsQuerry getListBrandsQuerry = new(){PageRequest = pageRequest};
            BrandListModel result = await Mediator.Send(getListBrandsQuerry);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandsQuerry getByIdBrandsQuerry)
        {
            BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdBrandsQuerry);
            return Ok(brandGetByIdDto);
        }
    }
}
