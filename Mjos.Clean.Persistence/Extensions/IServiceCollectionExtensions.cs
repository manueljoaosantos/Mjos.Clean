using Mjos.Clean.Application.Interfaces.Repositories;
using Mjos.Clean.Persistence.Contexts;
using Mjos.Clean.Persistence.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Mjos.Clean.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
            services.AddContextSeed(configuration);
        }

        //private static void AddMappings(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //}

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Mjsantos:SqlDb1");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static async void AddContextSeed(this IServiceCollection services, IConfiguration configuration)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

                // Ensure the database exists and is up-to-date
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                await ApplicationDbContextSeed.SeedAsync(context, configuration);
            }
        }


        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IPlayerRepository, PlayerRepository>()
                .AddTransient<IClubRepository, ClubRepository>()
                .AddTransient<IStadiumRepository, StadiumRepository>()
                .AddTransient<ICountryRepository, CountryRepository>()
                .AddTransient<ITeamSquadRepository, TeamSquadRepository>();
        }
    }
}
