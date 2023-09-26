using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mjos.Clean.Application.Features.Players.Queries.GetPlayersWithPagination
{
    public class GetPlayersByClubDto : IMapFrom<Player>
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
