using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjos.Clean.Application.Features.Clubs.Queries.GetAllClubs
{
    public class GetAllClubsDto : IMapFrom<Club>
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
