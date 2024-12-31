using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.Clubs.Queries.GetAllStadiums
{
    public record GetAllStadiumsQuery : IRequest<Result<List<GetAllStadiumsDto>>>;

    internal class GetAllStadiumsQueryHandler : IRequestHandler<GetAllStadiumsQuery, Result<List<GetAllStadiumsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllStadiumsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllStadiumsDto>>> Handle(GetAllStadiumsQuery query, CancellationToken cancellationToken)
        {
            var players = await _unitOfWork.Repository<Stadium>().Entities
                   .ProjectTo<GetAllStadiumsDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllStadiumsDto>>.SuccessAsync(players);
        }
    }
}
