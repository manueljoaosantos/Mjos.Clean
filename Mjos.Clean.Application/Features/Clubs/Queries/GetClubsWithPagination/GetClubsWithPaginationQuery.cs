using AutoMapper;
using AutoMapper.QueryableExtensions;

using Mjos.Clean.Application.Extensions;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;
using MediatR; 

namespace Mjos.Clean.Application.Features.Players.Queries.GetClubsWithPagination
{
    public record GetClubsWithPaginationQuery : IRequest<PaginatedResult<GetClubsWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetClubsWithPaginationQuery() { }

        public GetClubsWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        } 
    }

    internal class GetClubsWithPaginationQueryHandler : IRequestHandler<GetClubsWithPaginationQuery, PaginatedResult<GetClubsWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetClubsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetClubsWithPaginationDto>> Handle(GetClubsWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Club>().Entities
                   .OrderBy(x => x.Name) 
                   .ProjectTo<GetClubsWithPaginationDto>(_mapper.ConfigurationProvider)
                   .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
