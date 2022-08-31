using Domain.Entities;
using Persistence.Contexts;
using Application.Services.Repositories;
using Core.Persistence.Repositories;

namespace Persistence.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        public BrandRepository(BaseDbContext context) : base(context)
        {
        }

    }
}
