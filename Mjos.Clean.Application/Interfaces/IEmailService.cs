using Mjos.Clean.Application.DTOs.Email;

namespace Mjos.Clean.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}
