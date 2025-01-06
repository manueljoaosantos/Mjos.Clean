using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Persistence.Repositories
{
    public class TeamSquadRepository : ITeamSquadRepository
    {
        private readonly IGenericRepository<TeamSquad> _repository;

        public TeamSquadRepository(IGenericRepository<TeamSquad> repository) 
        {
            _repository = repository;
        }
    }
}
