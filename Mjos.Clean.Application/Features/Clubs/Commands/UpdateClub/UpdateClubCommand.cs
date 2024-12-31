using AutoMapper;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

using MediatR;
using Mjos.Clean.Application.Features.Players.Commands.UpdateClub;

namespace Mjos.Clean.Application.Features.Players.Commands.UpdatePlayer
{
    public record UpdateClubCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string FacebookUrl { get; set; } = string.Empty;
        public string TwitterUrl { get; set; } = string.Empty;
        public string YoutubeUrl { get; set; } = string.Empty;
        public string InstagramUrl { get; set; } = string.Empty;
    }

    internal class UpdateClubCommandHandler : IRequestHandler<UpdateClubCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateClubCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }

        public async Task<Result<int>> Handle(UpdateClubCommand command, CancellationToken cancellationToken)
        {
            var club = await _unitOfWork.Repository<Club>().GetByIdAsync(command.Id);
            if (club != null)
            {
                club.Name = command.Name;
                club.YoutubeUrl = command.YoutubeUrl;
                club.PhotoUrl = command.PhotoUrl;
                club.FacebookUrl = command.FacebookUrl;
                club.InstagramUrl = command.InstagramUrl;
                club.TwitterUrl = command.TwitterUrl;
                club.WebsiteUrl = command.WebsiteUrl;

                await _unitOfWork.Repository<Club>().UpdateAsync(club);
                club.AddDomainEvent(new ClubUpdatedEvent(club));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(club.Id, "Club Updated.");
            }
            else
            {
                return await Result<int>.FailureAsync("Club Not Found.");
            }               
        }
    }
}
