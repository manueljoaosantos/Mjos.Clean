using AutoMapper;

using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

using MediatR;

namespace Mjos.Clean.Application.Features.Players.Commands.DeleteClub
{
    public record DeleteClubCommand : IRequest<Result<int>>, IMapFrom<Club>
    {
        public int Id { get; set; }

        public DeleteClubCommand()
        {

        }

        public DeleteClubCommand(int id)
        {
            Id = id; 
        }
    }

    internal class DeleteClubCommandHandler : IRequestHandler<DeleteClubCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteClubCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteClubCommand command, CancellationToken cancellationToken)
        {
            var club = await _unitOfWork.Repository<Club>().GetByIdAsync(command.Id);
            if (club != null)
            {
                await _unitOfWork.Repository<Club>().DeleteAsync(club);
                club.AddDomainEvent(new ClubDeletedEvent(club));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(club.Id, "Club Deleted");
            }
            else
            {
                return await Result<int>.FailureAsync("Club Not Found.");
            }
        }
    }
}
