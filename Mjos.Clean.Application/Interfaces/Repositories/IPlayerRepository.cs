using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetPlayersByClubAsync(int clubId);
    }
}
