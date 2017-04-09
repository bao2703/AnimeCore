﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace AnimeCore.DataInitializer
{
    public class AdvertisementSeeder
    {
        public static async Task InitializeAsync(IApplicationBuilder app)
        {
            var unitOfWork = app.ApplicationServices.GetService<IUnitOfWork>();
            await InitializeVideoAdvertisementAsync(app);
            await InitializeCustomerAsync(app);
            await unitOfWork.SaveChangesAsync();
        }

        private static async Task InitializeCustomerAsync(IApplicationBuilder app)
        {
            var repository = app.ApplicationServices.GetService<ICustomerRepository>();

            var customers = new List<Customer>
            {
                new Customer
                {
                    Name = "Bảo",
                    Email = "bao@gmail.com",
                    Address = "Neptune"
                },
                new Customer
                {
                    Name = "Bảo2",
                    Email = "bao2@gmail.com",
                    Address = "Neptune"
                },
                new Customer
                {
                    Name = "Bảo3",
                    Email = "bao3@gmail.com",
                    Address = "Neptune"
                },
                new Customer
                {
                    Name = "Bảo4",
                    Email = "bao4@gmail.com",
                    Address = "Neptune"
                }
            };

            await repository.AddRangeAsync(customers);
        }

        private static async Task InitializeVideoAdvertisementAsync(IApplicationBuilder app)
        {
            var adsLocationRepository = app.ApplicationServices.GetService<IVideoAdsLocationRepository>();

            var adsLocations = new List<VideoAdsLocation>
            {
                new VideoAdsLocation
                {
                    Name = "Popular video",
                    Desciption = "Popular video"
                },
                new VideoAdsLocation
                {
                    Name = "Newest video",
                    Desciption = "Newest video"
                }
            };

            await adsLocationRepository.AddRangeAsync(adsLocations);

            var adsRepository = app.ApplicationServices.GetService<IVideoAdsRepository>();

            var videoAds = new List<VideoAds>
            {
                new VideoAds
                {
                    Name = "Neptune",
                    Description = "Neptune",
                    Title = "Neptune",
                    Url = "123123",
                    Video = "123123",
                    VideoAdsLocation = adsLocations.Single(x => x.Name == "Popular video")
                }
            };

            await adsRepository.AddRangeAsync(videoAds);
        }
    }
}