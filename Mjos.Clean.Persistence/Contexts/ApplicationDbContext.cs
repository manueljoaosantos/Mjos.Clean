using Mjos.Clean.Domain.Common;
using Mjos.Clean.Domain.Common.Interfaces;
using Mjos.Clean.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Mjos.Clean.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public ApplicationDbContext()
        { }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        //  IDomainEventDispatcher dispatcher)
        //    : base(options)
        //{
        //    _dispatcher = dispatcher;
        //}

        public DbSet<Club> Clubs => Set<Club>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Stadium> Stadiums => Set<Stadium>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<TeamSquad> TeamSquads => Set<TeamSquad>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
