using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.TeamSquads.Commands.CreateTeamSquad
{
    public class TeamSquadCreatedEvent : BaseEvent
    {
        public TeamSquad _teamSquad { get; }

        public TeamSquadCreatedEvent(TeamSquad teamSquad)
        {
            _teamSquad = teamSquad;
        }
    }
}
