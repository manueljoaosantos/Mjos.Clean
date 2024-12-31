using AutoMapper;
using MediatR;
using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.Clubs.Commands.CreateCountry
{

    public record CreateCountryCommand : IRequest<Result<int>>, IMapFrom<Country>
    {
        public string Name { get; set; } = string.Empty;
        public string TwoLetterIsoCode { get; set; } = string.Empty;
        public string ThreeLetterIsoCode { get; set; } = string.Empty;
        public string FlagUrl { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; }
    }

    internal class CreateClubCommandHandler : IRequestHandler<CreateCountryCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateClubCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var country = new Country()
            {
                Name = command.Name,
                TwoLetterIsoCode = command.TwoLetterIsoCode,
                ThreeLetterIsoCode = command.ThreeLetterIsoCode,
                FlagUrl = command.FlagUrl,
                DisplayOrder = command.DisplayOrder,
                CreatedDate = DateTime.UtcNow,
            };

            await _unitOfWork.Repository<Country>().AddAsync(country);
            country.AddDomainEvent(new CountryCreatedEvent(country));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(country.Id, "Country Created.");
        }
    }
}
