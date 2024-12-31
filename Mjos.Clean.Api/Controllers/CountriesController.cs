using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mjos.Clean.Application.Features.Clubs.Commands.CreateCountry;
using Mjos.Clean.Application.Features.Clubs.Queries.GetAllCountries;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Api.Controllers
{
    public class CountriesController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<Country> _genericRep;

        public CountriesController(IMediator mediator, IGenericRepository<Country> genericRep)
        {
            _mediator = mediator;
            _genericRep = genericRep;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllCountriesDto>>>> Get()
        {
            List<Country> l = await _genericRep.GetAllAsync();
            return await _mediator.Send(new GetAllCountriesQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateCountryCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
