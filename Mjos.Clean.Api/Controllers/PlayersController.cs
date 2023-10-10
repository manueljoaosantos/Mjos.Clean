using Mjos.Clean.Application.Features.Players.Commands.CreatePlayer;
using Mjos.Clean.Application.Features.Players.Commands.DeletePlayer;
using Mjos.Clean.Application.Features.Players.Commands.UpdatePlayer;
using Mjos.Clean.Application.Features.Players.Queries.GetPlayersWithPagination;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Mjos.Clean.Api.Controllers
{
    public class PlayersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<Player> _genericRep;

        public PlayersController(IMediator mediator, IGenericRepository<Player> genericRep)
        {
            _mediator = mediator;
            _genericRep = genericRep;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllPlayersDto>>>> Get()
        {
            List<Player> l = await _genericRep.GetAllAsync();
            return await _mediator.Send(new GetAllPlayersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetPlayerByIdDto>>> GetPlayersById(int id)
        {
            return await _mediator.Send(new GetPlayerByIdQuery(id)); 
        }

        [HttpGet]
        [Route("club/{clubId}")]
        public async Task<ActionResult<Result<List<GetPlayersByClubDto>>>> GetPlayersByClub(int clubId)
        {
            return await _mediator.Send(new GetPlayersByClubQuery(clubId));
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetPlayersWithPaginationDto>>> GetPlayersWithPagination([FromQuery] GetPlayersWithPaginationQuery query)
        {
            var validator = new GetPlayersWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages); 
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreatePlayerCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<int>>> Update(int id, UpdatePlayerCommand command)
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
            return await _mediator.Send(new DeletePlayerCommand(id)); 
        }
    }
}
