using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
