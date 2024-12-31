using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Players.Commands.UpdateClub
{
    public class ClubUpdatedEvent : BaseEvent
    {
        public Club _club { get; }

        public ClubUpdatedEvent(Club club)
        {
            _club = club;
        }
    }
}
