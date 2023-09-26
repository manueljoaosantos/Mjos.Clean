﻿using AutoMapper;
using AutoMapper.QueryableExtensions;

using Mjos.Clean.Application.Extensions;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Common.Interfaces;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;
using MediatR;

using Microsoft.EntityFrameworkCore; 

namespace Mjos.Clean.Application.Features.Players.Queries.GetPlayersWithPagination
{
    public record GetPlayerByIdQuery : IRequest<Result<GetPlayerByIdDto>>
    {
        public int Id { get; set; }

        public GetPlayerByIdQuery()
        {

        }

        public GetPlayerByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Result<GetPlayerByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlayerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetPlayerByIdDto>> Handle(GetPlayerByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Player>().GetByIdAsync(query.Id);
            var player = _mapper.Map<GetPlayerByIdDto>(entity);
            return await Result<GetPlayerByIdDto>.SuccessAsync(player);
        }
    }
}
