using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mjos.Clean.Application.Features.TeamSquads.Commands.CreateTeamSquad;
using Mjos.Clean.Application.Features.TeamSquads.Queries.GetAllTeamSquads;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Api.Controllers
{
    public class TeamSquadsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGenericRepository<TeamSquad> _genericRep;

        public TeamSquadsController(IMediator mediator, IGenericRepository<TeamSquad> genericRep)
        {
            _mediator = mediator;
            _genericRep = genericRep;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllTeamSquadsDto>>>> Get()
        {
            List<TeamSquad> l = await _genericRep.GetAllAsync();
            return await _mediator.Send(new GetAllTeamSquadsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateTeamSquadCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}
