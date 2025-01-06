using Mjos.Clean.Domain.Common;

namespace Mjos.Clean.Domain.Entities
{
    public class Stadium : BaseAuditableEntity
    {
        public Stadium()
        {
            Clubs = new List<Club>();
        }

        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public int? Capacity { get; set; }
        public int? BuiltYear { get; set; }
        public int? PitchLength { get; set; }
        public int? PitchWidth { get; set; }
        public string? Phone { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? CountryId { get; set; }

        public Country Country { get; set; } = new();
        public IList<Club> Clubs { get; set; }
         
    }
}
