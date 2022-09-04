using Application.Services.Repositories;
using Core.CrossCuttingConcers.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandyRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandyRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Brand name exists.");
        }
        public async Task BrandShouldExistWhenRequested(int Id)
        {
            Brand brand = await _brandyRepository.GetAsync(b => b.Id == Id);
            if (brand == null) throw new BusinessException("Requested Brand does not exist.");
        }
        public void BrandShouldExistWhenRequested(Brand brand)
        {
            if (brand == null) throw new BusinessException("Requested brand does not exist");
        }
    }
}
