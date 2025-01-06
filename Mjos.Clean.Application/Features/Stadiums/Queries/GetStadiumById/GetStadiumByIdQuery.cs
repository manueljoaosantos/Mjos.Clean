using AutoMapper;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;
using MediatR;

namespace Mjos.Clean.Application.Features.Stadiums.Queries.GetStadiumById
{
    public record GetStadiumByIdQuery : IRequest<Result<GetStadiumByIdDto>>
    {
        public int Id { get; set; }

        public GetStadiumByIdQuery()
        {

        }

        public GetStadiumByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetClubByIdQueryHandler : IRequestHandler<GetStadiumByIdQuery, Result<GetStadiumByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClubByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetStadiumByIdDto>> Handle(GetStadiumByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Stadium>().GetByIdAsync(query.Id);
            var stadium = _mapper.Map<GetStadiumByIdDto>(entity);
            return await Result<GetStadiumByIdDto>.SuccessAsync(stadium);
        }
    }
}
