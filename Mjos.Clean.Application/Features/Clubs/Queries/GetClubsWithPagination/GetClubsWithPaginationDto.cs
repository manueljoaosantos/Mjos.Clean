using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Players.Queries.GetClubsWithPagination
{
    public class GetClubsWithPaginationDto : IMapFrom<Club>
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public int ShirtNo { get; init; }
        public int HeightInCm { get; init; }
        public string FacebookUrl { get; init; } = string.Empty;
        public string TwitterUrl { get; init; } = string.Empty;
        public string InstagramUrl { get; init; } = string.Empty;
        public int DisplayOrder { get; init; }
    }
}
