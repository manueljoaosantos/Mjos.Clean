using AutoMapper;
using MediatR;

using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Shared;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Application.Common.Mappings;

namespace Mjos.Clean.Application.Features.Players.Commands.CreatePlayer
{
    public record CreatePlayerCommand : IRequest<Result<int>>, IMapFrom<Player>
    {
        public string Name { get; set; } = string.Empty;
        public int ShirtNo { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }

    internal class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }

        public async Task<Result<int>> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
        {
            var player = new Player()
            {
                Name = command.Name,
                ShirtNo = command.ShirtNo,
                PhotoUrl = command.PhotoUrl,
                BirthDate = command.BirthDate
            };

            await _unitOfWork.Repository<Player>().AddAsync(player);
            player.AddDomainEvent(new PlayerCreatedEvent(player));

            await _unitOfWork.Save(cancellationToken);

            return await Result<int>.SuccessAsync(player.Id, "Player Created.");
        }
    }
}
