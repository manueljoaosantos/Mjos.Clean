using FluentValidation;

namespace Mjos.Clean.Application.Features.Players.Queries.GetClubsWithPagination
{
    public class GetClubsWithPaginationValidator : AbstractValidator<GetClubsWithPaginationQuery>
    {
        public GetClubsWithPaginationValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
