using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Clubs.Queries.GetAllStadiums
{
    public class GetAllStadiumsDto : IMapFrom<Stadium>
    {
        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public int? Capacity { get; set; }
        public int? BuiltYear { get; set; }
        public int? PitchLength { get; set; }
        public int? PitchWidth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string AddressLine3 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public int? CountryId { get; set; }
    }
}
