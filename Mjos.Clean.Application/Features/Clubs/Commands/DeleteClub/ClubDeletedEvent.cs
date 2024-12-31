using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Players.Commands.DeleteClub
{
    public class ClubDeletedEvent : BaseEvent
    {
        public Club Club { get; }

        public ClubDeletedEvent(Club club)
        {
            Club = club;
        }
    }
}
