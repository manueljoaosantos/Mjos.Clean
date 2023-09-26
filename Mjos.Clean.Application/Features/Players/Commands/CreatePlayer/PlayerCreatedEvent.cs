using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Players.Commands.CreatePlayer
{
    public class PlayerCreatedEvent : BaseEvent
    {
        public Player Player { get; }

        public PlayerCreatedEvent(Player player)
        {
            Player = player;
        }
    }
}
