using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Interfaces.Repositories
{
    public interface IClubRepository
    {
        Task<List<Club>> GetClubsByStadiumAsync(int stadiumId);
    }
}
