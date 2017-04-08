﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Migrations
{
    [DbContext(typeof(NeptuneContext))]
    internal class NeptuneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Domain.AdsLocation", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Desciption");

                b.Property<string>("Name");

                b.HasKey("Id");

                b.ToTable("AdsLocations");
            });

            modelBuilder.Entity("Entities.Domain.AdsType", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Description");

                b.Property<long>("Price");

                b.HasKey("Id");

                b.ToTable("AdsTypes");
            });

            modelBuilder.Entity("Entities.Domain.Advertisement", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int?>("AdsLocationId");

                b.Property<int?>("AdsTypeId");

                b.Property<DateTime?>("CreatedDate");

                b.Property<string>("Description");

                b.Property<string>("Discriminator")
                    .IsRequired();

                b.Property<DateTime?>("LastModifiedDate");

                b.Property<string>("Name");

                b.Property<string>("Title");

                b.Property<string>("Url");

                b.HasKey("Id");

                b.HasIndex("AdsLocationId");

                b.HasIndex("AdsTypeId");

                b.ToTable("Advertisements");

                b.HasDiscriminator<string>("Discriminator").HasValue("Advertisement");
            });

            modelBuilder.Entity("Entities.Domain.Customer", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Address");

                b.Property<DateTime?>("CreatedDate");

                b.Property<string>("Email");

                b.Property<DateTime?>("LastModifiedDate");

                b.Property<string>("Name");

                b.HasKey("Id");

                b.ToTable("Customers");
            });

            modelBuilder.Entity("Entities.Domain.Episode", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime?>("CreatedDate");

                b.Property<DateTime?>("LastModifiedDate");

                b.Property<int?>("MovieId");

                b.Property<string>("Name");

                b.Property<string>("Url");

                b.HasKey("Id");

                b.HasIndex("MovieId");

                b.ToTable("Episodes");
            });

            modelBuilder.Entity("Entities.Domain.Genre", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Name");

                b.Property<string>("Slug");

                b.Property<string>("Title");

                b.HasKey("Id");

                b.ToTable("Genres");
            });

            modelBuilder.Entity("Entities.Domain.GenreMovie", b =>
            {
                b.Property<int>("MovieId");

                b.Property<int>("GenreId");

                b.HasKey("MovieId", "GenreId");

                b.HasIndex("GenreId");

                b.ToTable("GenreMovie");
            });

            modelBuilder.Entity("Entities.Domain.Invoice", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime?>("CreatedDate");

                b.Property<int?>("CustomerId");

                b.Property<DateTime?>("LastModifiedDate");

                b.Property<long>("TotalPrice");

                b.HasKey("Id");

                b.HasIndex("CustomerId");

                b.ToTable("Invoices");
            });

            modelBuilder.Entity("Entities.Domain.InvoiceDetail", b =>
            {
                b.Property<int>("InvoiceId");

                b.Property<int>("AdvertisementId");

                b.Property<long>("Click");

                b.Property<DateTime>("EndDate");

                b.Property<long>("Hover");

                b.Property<long>("Price");

                b.Property<DateTime>("StartDate");

                b.Property<long>("View");

                b.HasKey("InvoiceId", "AdvertisementId");

                b.HasIndex("AdvertisementId");

                b.ToTable("InvoiceDetail");
            });

            modelBuilder.Entity("Entities.Domain.Movie", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime?>("CreatedDate");

                b.Property<string>("Description");

                b.Property<string>("Fansub");

                b.Property<string>("Image");

                b.Property<DateTime?>("LastModifiedDate");

                b.Property<string>("Name")
                    .IsRequired();

                b.Property<string>("Quality");

                b.Property<float>("Rating");

                b.Property<DateTime>("Release");

                b.Property<string>("Slug");

                b.Property<int>("Status");

                b.Property<long>("View");

                b.Property<int>("Vote");

                b.HasKey("Id");

                b.ToTable("Movies");
            });

            modelBuilder.Entity("Entities.Domain.Role", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Description");

                b.Property<string>("Name")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedName")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasName("RoleNameIndex");

                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity("Entities.Domain.User", b =>
            {
                b.Property<string>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<int>("AccessFailedCount");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken();

                b.Property<string>("Email")
                    .HasMaxLength(256);

                b.Property<bool>("EmailConfirmed");

                b.Property<bool>("LockoutEnabled");

                b.Property<DateTimeOffset?>("LockoutEnd");

                b.Property<string>("NormalizedEmail")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedUserName")
                    .HasMaxLength(256);

                b.Property<string>("PasswordHash");

                b.Property<string>("PhoneNumber");

                b.Property<bool>("PhoneNumberConfirmed");

                b.Property<string>("SecurityStamp");

                b.Property<bool>("TwoFactorEnabled");

                b.Property<string>("UserName")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedEmail")
                    .HasName("EmailIndex");

                b.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasName("UserNameIndex");

                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<string>("RoleId")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("ClaimType");

                b.Property<string>("ClaimValue");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider");

                b.Property<string>("ProviderKey");

                b.Property<string>("ProviderDisplayName");

                b.Property<string>("UserId")
                    .IsRequired();

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId");

                b.Property<string>("RoleId");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.ToTable("AspNetUserRoles");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId");

                b.Property<string>("LoginProvider");

                b.Property<string>("Name");

                b.Property<string>("Value");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity("Entities.Domain.BannerAds", b =>
            {
                b.HasBaseType("Entities.Domain.Advertisement");

                b.Property<string>("Image");

                b.ToTable("BannerAds");

                b.HasDiscriminator().HasValue("BannerAds");
            });

            modelBuilder.Entity("Entities.Domain.VideoAds", b =>
            {
                b.HasBaseType("Entities.Domain.Advertisement");

                b.Property<string>("VideoUrl");

                b.ToTable("VideoAds");

                b.HasDiscriminator().HasValue("VideoAds");
            });

            modelBuilder.Entity("Entities.Domain.Advertisement", b =>
            {
                b.HasOne("Entities.Domain.AdsLocation", "AdsLocation")
                    .WithMany("Advertisements")
                    .HasForeignKey("AdsLocationId");

                b.HasOne("Entities.Domain.AdsType", "AdsType")
                    .WithMany("Advertisements")
                    .HasForeignKey("AdsTypeId");
            });

            modelBuilder.Entity("Entities.Domain.Episode", b =>
            {
                b.HasOne("Entities.Domain.Movie", "Movie")
                    .WithMany("Episodes")
                    .HasForeignKey("MovieId");
            });

            modelBuilder.Entity("Entities.Domain.GenreMovie", b =>
            {
                b.HasOne("Entities.Domain.Genre", "Genre")
                    .WithMany("GenreMovies")
                    .HasForeignKey("GenreId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Entities.Domain.Movie", "Movie")
                    .WithMany("GenreMovies")
                    .HasForeignKey("MovieId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Entities.Domain.Invoice", b =>
            {
                b.HasOne("Entities.Domain.Customer")
                    .WithMany("Invoices")
                    .HasForeignKey("CustomerId");
            });

            modelBuilder.Entity("Entities.Domain.InvoiceDetail", b =>
            {
                b.HasOne("Entities.Domain.Advertisement", "Advertisement")
                    .WithMany("InvoiceDetails")
                    .HasForeignKey("AdvertisementId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Entities.Domain.Invoice", "Invoice")
                    .WithMany("InvoiceDetails")
                    .HasForeignKey("InvoiceId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
            {
                b.HasOne("Entities.Domain.Role")
                    .WithMany("Claims")
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
            {
                b.HasOne("Entities.Domain.User")
                    .WithMany("Claims")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
            {
                b.HasOne("Entities.Domain.User")
                    .WithMany("Logins")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
            {
                b.HasOne("Entities.Domain.Role")
                    .WithMany("Users")
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("Entities.Domain.User")
                    .WithMany("Roles")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}