using AutoMapper;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;
using MediatR;

namespace Mjos.Clean.Application.Features.Players.Queries.GetClubById
{
    public record GetClubByIdQuery : IRequest<Result<GetClubByIdDto>>
    {
        public int Id { get; set; }

        public GetClubByIdQuery()
        {

        }

        public GetClubByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetClubByIdQueryHandler : IRequestHandler<GetClubByIdQuery, Result<GetClubByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClubByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetClubByIdDto>> Handle(GetClubByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Club>().GetByIdAsync(query.Id);
            var player = _mapper.Map<GetClubByIdDto>(entity);
            return await Result<GetClubByIdDto>.SuccessAsync(player);
        }
    }
}
