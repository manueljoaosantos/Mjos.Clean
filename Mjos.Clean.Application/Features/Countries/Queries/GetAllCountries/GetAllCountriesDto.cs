using Mjos.Clean.Application.Common.Mappings;
using Mjos.Clean.Domain.Entities;

namespace Mjos.Clean.Application.Features.Clubs.Queries.GetAllCountries
{
    public class GetAllCountriesDto : IMapFrom<Country>
    {
        public string Name { get; set; } = string.Empty;
        public string TwoLetterIsoCode { get; set; } = string.Empty;
        public string ThreeLetterIsoCode { get; set; } = string.Empty;
        public string FlagUrl { get; set; } = string.Empty;
        public int? DisplayOrder { get; set; }
    }
}
