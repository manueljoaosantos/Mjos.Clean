using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Mjos.Clean.Persistence.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IGenericRepository<Player> _repository;

        public PlayerRepository(IGenericRepository<Player> repository) 
        {
            _repository = repository;
        }

        public async Task<List<Player>> GetPlayersByClubAsync(int clubId)
        {
            return await _repository.Entities.Where(x => x.ClubId == clubId).ToListAsync();
        }
    }
}
