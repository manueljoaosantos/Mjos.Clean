using Mjos.Clean.Domain.Common;

namespace Mjos.Clean.Domain.Entities
{
    public class Club : BaseAuditableEntity
    {
        public Club()
        {
            Players = new List<Player>();
        }

        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string FacebookUrl { get; set; } = string.Empty;
        public string TwitterUrl { get; set; } = string.Empty;
        public string YoutubeUrl { get; set; } = string.Empty;
        public string InstagramUrl { get; set; } = string.Empty;
        public int? StadiumId { get; set; }

        public Stadium Stadium { get; set; } = new();
        public IList<Player> Players { get; set; }
    }
}

