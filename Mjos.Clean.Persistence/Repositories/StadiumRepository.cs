using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
