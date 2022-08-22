using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
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
            if (result.Items.Any()) throw new BusinessException("SomeFeatureEntity name exists.");
        }
    }
}
