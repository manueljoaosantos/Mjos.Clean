using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Mjos.Clean.Persistence.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly IGenericRepository<Club> _repository;

        public ClubRepository(IGenericRepository<Club> repository) 
        {
            _repository = repository;
        }

        public async Task<List<Club>> GetClubsByStadiumAsync(int stadiumId)
        {
            return await _repository.Entities.Where(x => x.StadiumId == stadiumId).ToListAsync();
        }
    }
}
