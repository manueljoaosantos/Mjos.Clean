using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.Clubs.Queries.GetAllCountries
{
    public record GetAllCountriesQuery : IRequest<Result<List<GetAllCountriesDto>>>;

    internal class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, Result<List<GetAllCountriesDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCountriesDto>>> Handle(GetAllCountriesQuery query, CancellationToken cancellationToken)
        {
            var countries = await _unitOfWork.Repository<Country>().Entities
                   .ProjectTo<GetAllCountriesDto>(_mapper.ConfigurationProvider)
                   .ToListAsync(cancellationToken);

            return await Result<List<GetAllCountriesDto>>.SuccessAsync(countries);
        }
    }
}
