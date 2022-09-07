using Domain.Entities;
using Persistence.Contexts;
using Application.Services.Repositories;
using Core.Persistence.Repositories;

namespace Persistence.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
    {
        public ModelRepository(BaseDbContext context) : base(context)
        {
        }

    }
}