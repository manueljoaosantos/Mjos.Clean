using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mjos.Clean.Application.Features.Clubs.Commands.CreateClub;
using Mjos.Clean.Application.Features.Clubs.Queries.GetAllClubs;
using Mjos.Clean.Application.Features.Players.Commands.DeleteClub;
using Mjos.Clean.Application.Features.Players.Commands.UpdatePlayer;
using Mjos.Clean.Application.Features.Players.Queries.GetClubById;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Api.Controllers
{
    public class ClubsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<Club> _genericRep;

        public ClubsController(IMediator mediator, IGenericRepository<Club> genericRep)
        {
            _mediator = mediator;
            _genericRep = genericRep;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllClubsDto>>>> Get()
        {
            List<Club> l = await _genericRep.GetAllAsync();
            return await _mediator.Send(new GetAllClubsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateClubCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Update(int id, UpdateClubCommand command)
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
            return await _mediator.Send(new DeleteClubCommand(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetClubByIdDto>>> GetClubsById(int id)
        {
            return await _mediator.Send(new GetClubByIdQuery(id));
        }
    }
}
