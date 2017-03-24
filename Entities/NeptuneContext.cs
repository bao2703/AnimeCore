using System;
using System.Linq;
using Entities.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class NeptuneContext : IdentityDbContext<User>
    {
        public NeptuneContext(DbContextOptions<NeptuneContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GenreMovie>().HasKey(x => new {x.MovieId, x.GenreId});
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var entities =
                ChangeTracker.Entries()
                    .Where(
                        x =>
                            x.Entity is TrackAbleEntity &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                    ((TrackAbleEntity) entity.Entity).CreatedDate = DateTime.UtcNow;

                ((TrackAbleEntity) entity.Entity).LastModifiedDate = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}