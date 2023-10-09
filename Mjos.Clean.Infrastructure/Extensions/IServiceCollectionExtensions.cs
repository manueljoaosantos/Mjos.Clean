using Mjos.Clean.Application.Interfaces;
using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Common.Interfaces;
using Mjos.Clean.Infrastructure.Services;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Mjos.Clean.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IDateTimeService, DateTimeService>()
                .AddTransient<IEmailService, EmailService>();
        }
    }
}
