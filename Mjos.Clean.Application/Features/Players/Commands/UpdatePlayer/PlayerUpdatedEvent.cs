using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Players.Commands.UpdatePlayer
{
    public class PlayerUpdatedEvent : BaseEvent
    {
        public Player Player { get; }

        public PlayerUpdatedEvent(Player player)
        {
            Player = player;
        }
    }
}
