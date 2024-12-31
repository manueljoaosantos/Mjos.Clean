using AutoMapper;
using MediatR;
using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.Clubs.Commands.CreateStadium
{

    public record CreateStadiumCommand : IRequest<Result<int>>, IMapFrom<Stadium>
    {
        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public int? Capacity { get; set; }
        public int? BuiltYear { get; set; }
        public int? PitchLength { get; set; }
        public int? PitchWidth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string AddressLine3 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public int? CountryId { get; set; }
    }

    internal class CreateStadiumCommandHandler : IRequestHandler<CreateStadiumCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStadiumCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateStadiumCommand command, CancellationToken cancellationToken)
        {
            var stadium = new Stadium()
            {
                Name = command.Name,
                PhotoUrl = command.PhotoUrl,
                CreatedDate = DateTime.UtcNow,
                AddressLine1 = command.AddressLine1,
                AddressLine2 = command.AddressLine2,
                AddressLine3 = command.AddressLine3,
                City = command.City,
                BuiltYear = command.BuiltYear,
                Capacity = command.Capacity,
                CountryId = command.CountryId,
                PitchLength = command.PitchLength,
                Phone = command.Phone,
                PitchWidth = command.PitchWidth,
                PostalCode = command.PostalCode,

            };

            await _unitOfWork.Repository<Stadium>().AddAsync(stadium);
            stadium.AddDomainEvent(new StadiumCreatedEvent(stadium));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(stadium.Id, "Stadium Created.");
        }
    }
}
