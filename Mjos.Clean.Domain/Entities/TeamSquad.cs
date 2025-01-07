using Mjos.Clean.Domain.Common;

namespace Mjos.Clean.Domain.Entities
{
    public class TeamSquad : BaseAuditableEntity
    {
        public int ClubId { get; set; }
        public int PlayerId { get; set; }
        public int Year { get; set; }

        public Club? Club { get; set; }
        public Player? Player { get; set; }
    }
}
