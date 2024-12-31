using AutoMapper;
using MediatR;
using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

namespace Mjos.Clean.Application.Features.Clubs.Commands.CreateClub
{

    public record CreateClubCommand : IRequest<Result<int>>, IMapFrom<Club>
    {
        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string FacebookUrl { get; set; } = string.Empty;
        public string TwitterUrl { get; set; } = string.Empty;
        public string YoutubeUrl { get; set; } = string.Empty;
        public string InstagramUrl { get; set; } = string.Empty;
    }

    internal class CreateClubCommandHandler : IRequestHandler<CreateClubCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateClubCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateClubCommand command, CancellationToken cancellationToken)
        {
            var club = new Club()
            {
                Name = command.Name,
                PhotoUrl = command.PhotoUrl,
                TwitterUrl = command.TwitterUrl,
                InstagramUrl = command.InstagramUrl,
                FacebookUrl = command.FacebookUrl,
                CreatedDate = DateTime.UtcNow,
                WebsiteUrl = command.WebsiteUrl,
                YoutubeUrl = command.YoutubeUrl

            };

            await _unitOfWork.Repository<Club>().AddAsync(club);
            club.AddDomainEvent(new ClubCreatedEvent(club));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(club.Id, "Club Created.");
        }
    }
}
