using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Stadiums.Commands.DeleteStadium
{
    public class StadiumDeletedEvent : BaseEvent
    {
        public Stadium _stadium { get; }

        public StadiumDeletedEvent(Stadium stadium)
        {
            _stadium = stadium;
        }
    }
}
