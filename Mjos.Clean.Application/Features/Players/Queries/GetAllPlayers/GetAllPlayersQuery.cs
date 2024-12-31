﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;
using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Mjos.Clean.Application.Features.Players.Queries.GetPlayersWithPagination
{
    public record GetAllPlayersQuery : IRequest<Result<List<GetAllPlayersDto>>>;

    internal class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, Result<List<GetAllPlayersDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPlayersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllPlayersDto>>> Handle(GetAllPlayersQuery query, CancellationToken cancellationToken)
        { 
            var players = await _unitOfWork.Repository<Player>().Entities
                   .ProjectTo<GetAllPlayersDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllPlayersDto>>.SuccessAsync(players);
        }
    }
}
