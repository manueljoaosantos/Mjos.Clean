using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mjos.Clean.Application.Features.Stadiums.Commands.CreateStadium;
using Mjos.Clean.Application.Features.Stadiums.Queries.GetAllStadiums;
using Mjos.Clean.Application.Features.Stadiums.Commands.DeleteStadium;
using Mjos.Clean.Application.Features.Stadiums.Commands.UpdateStadium;
using Mjos.Clean.Application.Features.Stadiums.Queries.GetStadiumById;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Api.Controllers
{
    public class StadiumsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<Stadium> _genericRep;

        public StadiumsController(IMediator mediator, IGenericRepository<Stadium> genericRep)
        {
            _mediator = mediator;
            _genericRep = genericRep;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllStadiumsDto>>>> Get()
        {
            List<Stadium> l = await _genericRep.GetAllAsync();
            return await _mediator.Send(new GetAllStadiumsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateStadiumCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Update(int id, UpdateStadiumCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result<int>>> Delete(int id)
        {
            return await _mediator.Send(new DeleteStadiumCommand(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetStadiumByIdDto>>> GetClubsById(int id)
        {
            return await _mediator.Send(new GetStadiumByIdQuery(id));
        }
    }
}
