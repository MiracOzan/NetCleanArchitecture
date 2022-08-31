using Application.Features.Brands.Models;
using MediatR;

namespace Application.Features.Brands.Queries
{
    public class GetListBrands : IRequest<BrandListModel> 
    {
    }
}
