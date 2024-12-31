using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Clubs.Commands.CreateCountry
{
    public class CountryCreatedEvent : BaseEvent
    {
        public Country _country { get; }

        public CountryCreatedEvent(Country country)
        {
            _country = country;
        }
    }
}
