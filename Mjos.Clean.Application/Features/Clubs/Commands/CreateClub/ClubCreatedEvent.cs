using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Clubs.Commands.CreateClub
{
    public class ClubCreatedEvent : BaseEvent
    {
        public Club _club { get; }

        public ClubCreatedEvent(Club club)
        {
            _club = club;
        }
    }
}
