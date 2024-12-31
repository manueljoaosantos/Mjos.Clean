using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Clubs.Queries.GetClubsByStadium
{
    public class GetClubsByStadiumDto : IMapFrom<Club>
    {
        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string FacebookUrl { get; set; } = string.Empty;
        public string TwitterUrl { get; set; } = string.Empty;
        public string YoutubeUrl { get; set; } = string.Empty;
        public string InstagramUrl { get; set; } = string.Empty;
        public int? StadiumId { get; set; }
    }
}
