using Mjos.Clean.Application.Interfaces;
using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Common.Interfaces;
using Mjos.Clean.Infrastructure.Services;

using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

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

        public static void AddSwaggerGenWithAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSwaggerGen(o =>
            {
                o.CustomSchemaIds(id => id.FullName!.Replace('+', '-'));

                o.AddSecurityDefinition("Keycloak", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(configuration["Keycloak:AuthorizationUrl"]!),
                            Scopes = new Dictionary<string, string>
                            {
                                { "openid", "openid" },
                                { "profile", "profile" }
                            }
                        }
                    }
                });

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Keycloak",
                                Type = ReferenceType.SecurityScheme
                            },
                            In = ParameterLocation.Header,
                            Name = "Bearer",
                            Scheme = "Bearer"
                        },
                        new List<string>() // Empty list for scopes
                    }
                };
                o.AddSecurityRequirement(securityRequirement);
            });
        }

        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false; // Set to true in production
                    o.Audience = "YourAudienceHere"; // Replace with your actual audience
                    o.MetadataAddress = "YourMetadataAddressHere"; // Replace with your actual metadata address
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "YourValidIssuerHere" // Replace with your actual valid issuer
                    };
                });
        }

        public static void AddOpenTelemetryCustom(this IServiceCollection services)
        {
            services
                .AddOpenTelemetry()
                .ConfigureResource(resourse => resourse.AddService("Mjos.Clean.Api"))
                .WithTracing(tracing =>
                {
                    tracing
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation();
                    tracing.AddOtlpExporter();
                });
        }
    }
}
