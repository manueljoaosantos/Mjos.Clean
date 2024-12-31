using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Persistence.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IGenericRepository<Country> _repository;

        public CountryRepository(IGenericRepository<Country> repository) 
        {
            _repository = repository;
        } 
    }
}
