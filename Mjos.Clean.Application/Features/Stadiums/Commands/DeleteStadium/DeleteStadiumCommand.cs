using AutoMapper;

using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Domain.Entities;
using Mjos.Clean.Shared;

using MediatR;

namespace Mjos.Clean.Application.Features.Players.Commands.DeleteStadium
{
    public record DeleteStadiumCommand : IRequest<Result<int>>, IMapFrom<Stadium>
    {
        public int Id { get; set; }

        public DeleteStadiumCommand()
        {

        }

        public DeleteStadiumCommand(int id)
        {
            Id = id; 
        }
    }

    internal class DeleteStadiumCommandHandler : IRequestHandler<DeleteStadiumCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStadiumCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteStadiumCommand command, CancellationToken cancellationToken)
        {
            var stadium = await _unitOfWork.Repository<Stadium>().GetByIdAsync(command.Id);
            if (stadium != null)
            {
                await _unitOfWork.Repository<Stadium>().DeleteAsync(stadium);
                stadium.AddDomainEvent(new StadiumDeletedEvent(stadium));

                await _unitOfWork.Save(cancellationToken);

                return await Result<int>.SuccessAsync(stadium.Id, "Stadium Deleted");
            }
            else
            {
                return await Result<int>.FailureAsync("Stadium Not Found.");
            }
        }
    }
}
