using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Persistence.Repositories
{
    public class StadiumRepository : IStadiumRepository
    {
        private readonly IGenericRepository<Stadium> _repository;

        public StadiumRepository(IGenericRepository<Stadium> repository) 
        {
            _repository = repository;
        } 
    }
}
