using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Stadiums.Commands.CreateStadium
{
    public class StadiumCreatedEvent : BaseEvent
    {
        public Stadium _stadium { get; }

        public StadiumCreatedEvent(Stadium stadium)
        {
            _stadium = stadium;
        }
    }
}
