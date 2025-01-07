using Mjos.Clean.Domain.Common;

namespace Mjos.Clean.Domain.Entities
{
    public class Club : BaseAuditableEntity
    {
        public Club()
        {
            Players = new List<Player>();
            TeamSquads = new List<TeamSquad>();
        }

        public string Name { get; set; } = string.Empty;
        public string? PhotoUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? YoutubeUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public int? StadiumId { get; set; }

        public Stadium? Stadium { get; set; }
        public IList<Player>? Players { get; set; }
        public IList<TeamSquad> TeamSquads { get; set; }

    }
}

