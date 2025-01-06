using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Stadiums.Commands.UpdateStadium
{
    public class StadiumUpdatedEvent : BaseEvent
    {
        public Stadium _stadium { get; }

        public StadiumUpdatedEvent(Stadium stadium)
        {
            _stadium = stadium;
        }
    }
}
