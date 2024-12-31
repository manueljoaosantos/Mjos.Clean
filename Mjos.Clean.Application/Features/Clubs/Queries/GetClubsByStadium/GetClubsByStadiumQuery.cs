using AutoMapper;
using MediatR;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.Clubs.Queries.GetClubsByStadium
{
    public record GetClubsByStadiumQuery : IRequest<Result<List<GetClubsByStadiumDto>>>
    {
        public int StadiumId { get; set; }

        public GetClubsByStadiumQuery()
        {

        }

        public GetClubsByStadiumQuery(int stadiumId)
        {
            StadiumId = stadiumId;
        }
    }

    internal class GetClubsByStadiumQueryHandler : IRequestHandler<GetClubsByStadiumQuery, Result<List<GetClubsByStadiumDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClubRepository _clubRepository;



        public GetClubsByStadiumQueryHandler(IUnitOfWork unitOfWork, IClubRepository clubRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clubRepository = clubRepository;
        }

        public async Task<Result<List<GetClubsByStadiumDto>>> Handle(GetClubsByStadiumQuery query, CancellationToken cancellationToken)
        {
            var entities = await _clubRepository.GetClubsByStadiumAsync(query.StadiumId);
            var clubs = _mapper.Map<List<GetClubsByStadiumDto>>(entities);
            return await Result<List<GetClubsByStadiumDto>>.SuccessAsync(clubs);
        }
    }
}
