using Mjos.Clean.Application.Interfaces;

namespace Mjos.Clean.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}