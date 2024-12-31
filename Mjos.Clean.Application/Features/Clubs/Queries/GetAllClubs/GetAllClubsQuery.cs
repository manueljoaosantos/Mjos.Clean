using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.Clubs.Queries.GetAllClubs
{
    public record GetAllClubsQuery : IRequest<Result<List<GetAllClubsDto>>>;

    internal class GetAllClubsQueryHandler : IRequestHandler<GetAllClubsQuery, Result<List<GetAllClubsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllClubsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllClubsDto>>> Handle(GetAllClubsQuery query, CancellationToken cancellationToken)
        {
            var players = await _unitOfWork.Repository<Club>().Entities
                   .ProjectTo<GetAllClubsDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllClubsDto>>.SuccessAsync(players);
        }
    }
}
