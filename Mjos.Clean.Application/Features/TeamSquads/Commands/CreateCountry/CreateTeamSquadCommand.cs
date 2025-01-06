using AutoMapper;
using MediatR;
using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.TeamSquads.Commands.CreateTeamSquad
{

    public record CreateTeamSquadCommand : IRequest<Result<int>>, IMapFrom<TeamSquad>
    {
        public int ClubId { get; set; }
        public int PlayerId { get; set; }
        public int Year { get; set; }
    }

    internal class CreateTeamSquadCommandHandler : IRequestHandler<CreateTeamSquadCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTeamSquadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateTeamSquadCommand command, CancellationToken cancellationToken)
        {
            var teamSquad = new TeamSquad()
            {
                ClubId = command.ClubId,
                PlayerId = command.PlayerId,
                Year = command.Year,
                CreatedDate = DateTime.UtcNow,
            };

            await _unitOfWork.Repository<TeamSquad>().AddAsync(teamSquad);
            teamSquad.AddDomainEvent(new TeamSquadCreatedEvent(teamSquad));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(teamSquad.Id, "TeamSquad Created.");
        }
    }
}
