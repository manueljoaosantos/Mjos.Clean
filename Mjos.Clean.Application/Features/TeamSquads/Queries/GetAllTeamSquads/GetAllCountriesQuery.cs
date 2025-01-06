using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.TeamSquads.Queries.GetAllTeamSquads
{
    public record GetAllTeamSquadsQuery : IRequest<Result<List<GetAllTeamSquadsDto>>>;

    internal class GetAllTeamSquadsQueryHandler : IRequestHandler<GetAllTeamSquadsQuery, Result<List<GetAllTeamSquadsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTeamSquadsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllTeamSquadsDto>>> Handle(GetAllTeamSquadsQuery query, CancellationToken cancellationToken)
        {
            var teamSquads = await _unitOfWork.Repository<Country>().Entities
                   .ProjectTo<GetAllTeamSquadsDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllTeamSquadsDto>>.SuccessAsync(teamSquads);
        }
    }
}
