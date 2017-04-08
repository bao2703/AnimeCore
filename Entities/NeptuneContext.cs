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

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<BannerAds> BannerAdses { get; set; }

        public DbSet<VideoAds> VideoAdses { get; set; }

        public DbSet<AdsType> AdsTypes { get; set; }

        public DbSet<AdsLocation> AdsLocations { get; set; }

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

            builder.Entity<InvoiceDetail>().HasKey(x => new {x.InvoiceId, x.AdvertisementId});

            builder.Entity<InvoiceDetail>()
                .HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceDetails)
                .HasForeignKey(x => x.InvoiceId);

            builder.Entity<InvoiceDetail>()
                .HasOne(x => x.Advertisement)
                .WithMany(x => x.InvoiceDetails)
                .HasForeignKey(x => x.AdvertisementId);

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