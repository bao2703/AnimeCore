using System;
using System.Collections.Generic;
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
            var adsLocationRepository = app.ApplicationServices.GetService<IAdsLocationRepository>();

            var adsLocations = new List<AdsLocation>
            {
                new AdsLocation
                {
                    Name = "Popular",
                    Desciption = "Popular video"
                },
                new AdsLocation
                {
                    Name = "Newest",
                    Desciption = "Newest video"
                }
            };

            await adsLocationRepository.AddRangeAsync(adsLocations);

            var adsRepository = app.ApplicationServices.GetService<IAdvertisementRepository>();

            var videoAds = new List<Advertisement>
            {
                new Advertisement
                {
                    Name = "Neptune",
                    Description = "Neptune",
                    Title = "Neptune",
                    Url = "https://www.ford.com.vn/",
                    Source = "/assets/client/ads-example/ford-ads-example.MP4",
                    AdsType = AdsType.Video,
                    StartDate = new DateTime(2017, 4, 10),
                    EndDate = new DateTime(2017, 6, 10),
                    AdsLocation = adsLocations.Single(x => x.Name == "Popular")
                }
            };

            await adsRepository.AddRangeAsync(videoAds);
        }
    }
}