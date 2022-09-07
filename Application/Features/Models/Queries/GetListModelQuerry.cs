using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries
{
    public class GetListModelQuerry: IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListModelQuerryHandler : IRequestHandler<GetListModelQuerry, ModelListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelQuerryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetListModelQuerry request, CancellationToken cancellationToken)
            {
               IPaginate<Model> models = await _modelRepository.GetListAsync(include:
                    m => m.Include(c => c.Brand),
                                                    index:request.PageRequest.Page,
                                                    size:request.PageRequest.PageSize
                                                    );

               ModelListModel mapperModels = _mapper.Map<ModelListModel>(models);
               return mapperModels;
            }
        }
    }
}
