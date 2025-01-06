using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.TeamSquads.Queries.GetAllTeamSquads
{
    public class GetAllTeamSquadsDto : IMapFrom<TeamSquad>
    {
        public int ClubId { get; set; }
        public int PlayerId { get; set; }
        public int Year { get; set; }
    }
}
