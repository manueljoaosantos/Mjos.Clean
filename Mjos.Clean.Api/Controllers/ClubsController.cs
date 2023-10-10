using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mjos.Clean.Application.Features.Clubs.Commands.CreateClub;
using Mjos.Clean.Application.Features.Clubs.Queries.GetAllClubs;
using Mjos.Clean.Application.Features.Players.Commands.CreatePlayer;
using Mjos.Clean.Application.Features.Players.Queries.GetPlayersWithPagination;
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
    }
}
