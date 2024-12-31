using AutoMapper;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

using MediatR;
namespace Mjos.Clean.Application.Features.Players.Commands.UpdateStadium
{
    public record UpdateStadiumCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
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

    internal class UpdateStadiumCommandHandler : IRequestHandler<UpdateStadiumCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStadiumCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }

        public async Task<Result<int>> Handle(UpdateStadiumCommand command, CancellationToken cancellationToken)
        {
            var stadium = await _unitOfWork.Repository<Stadium>().GetByIdAsync(command.Id);
            if (stadium != null)
            {
                stadium.Name = command.Name;
                stadium.PhotoUrl = command.PhotoUrl;
                stadium.Capacity = command.Capacity;
                stadium.BuiltYear = command.BuiltYear;
                stadium.PitchLength = command.PitchLength;
                stadium.PitchWidth = command.PitchWidth;
                stadium.Phone = command.Phone;
                stadium.AddressLine1 = command.AddressLine1;
                stadium.AddressLine2 = command.AddressLine2;
                stadium.AddressLine3 = command.AddressLine3;
                stadium.City = command.City;
                stadium.PostalCode = command.PostalCode;
                stadium.CountryId = command.CountryId;

                await _unitOfWork.Repository<Stadium>().UpdateAsync(stadium);
                stadium.AddDomainEvent(new StadiumUpdatedEvent(stadium));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(stadium.Id, "Stadium Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("Stadium Not Found.");
            }               
        }
    }
}
