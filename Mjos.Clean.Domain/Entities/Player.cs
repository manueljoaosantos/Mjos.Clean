using Mjos.Clean.Domain.Common;

namespace Mjos.Clean.Domain.Entities
{
    public class Player : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public int? ShirtNo { get; set; }
        public int? ClubId { get; set; }
        public int? PlayerPositionId { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? HeightInCm { get; set; }
        public string FacebookUrl { get; set; } = string.Empty;
        public string TwitterUrl { get; set; } = string.Empty;
        public string InstagramUrl { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; }

        public Club Club { get; set; } = new();
        public Country Country { get; set; }= new();
        public IList<TeamSquad> TeamSquads { get; set; }

    }
}
