using System;
using System.Linq;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class NeptuneContext : IdentityDbContext<User, Role, string>
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

            builder.Entity<GenreMovie>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.GenreMovies)
                .HasForeignKey(x => x.MovieId);

            builder.Entity<GenreMovie>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.GenreMovies)
                .HasForeignKey(x => x.GenreId);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        public void AddTimestamps()
        {
            var entities =
                ChangeTracker.Entries()
                    .Where(
                        x =>
                            x.Entity is TimestampEntity &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((TimestampEntity) entity.Entity).CreatedDate = DateTime.Now;
                }

                ((TimestampEntity) entity.Entity).LastModifiedDate = DateTime.Now;
            }
        }
    }
}