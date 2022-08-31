using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries
{
    public class GetListBrandsQuerry : IRequest<BrandListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListBrandsQuerryHandler: IRequestHandler<GetListBrandsQuerry,BrandListModel>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetListBrandsQuerryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public Task<BrandListModel> Handle(GetListBrandsQuerry request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brands = await _brandRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                BrandListModel mappedBrandListModel = _mapper.Map<BrandListModel>(brands);
                return mappedBrandListModel;

            }
        }
    }
}
