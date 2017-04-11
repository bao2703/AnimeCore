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
                    Desciption = "Show ads on Popular movie",
                    AdsType = AdsType.Video,
                    LocationType = LocationType.Share,
                    Price = 100000
                },
                new AdsLocation
                {
                    Name = "Newest",
                    Desciption = "Show ads on Newest movie",
                    AdsType = AdsType.Video,
                    LocationType = LocationType.Share,
                    Price = 200000
                },
                new AdsLocation
                {
                    Name = "Normal",
                    Desciption = "Show ads on Normal movie",
                    AdsType = AdsType.Video,
                    LocationType = LocationType.Share,
                    Price = 200000
                }
            };

            await adsLocationRepository.AddRangeAsync(adsLocations);

            var adsRepository = app.ApplicationServices.GetService<IAdvertisementRepository>();

            var videoAds = new List<Advertisement>
            {
                new Advertisement
                {
                    Name = "Coca-Cola: Coke Mini (Hulk vs. Ant-Man)",
                    Description = "Coca-Cola: Coke Mini (Hulk vs. Ant-Man)",
                    Title = "Coca-Cola: Coke Mini (Hulk vs. Ant-Man)",
                    Url = "http://www.coca-colacompany.com/",
                    Source = "/assets/client/ads-example/coca-cola-coke-mini-hulk-vs-ant-man.mp4",
                    StartDate = new DateTime(2017, 3, 1),
                    EndDate = new DateTime(2017, 5, 1),
                    AdsLocation = adsLocations.Single(x => x.Name == "Popular")
                },
                new Advertisement
                {
                    Name = "Asus ROG G752",
                    Description = "Asus ROG G752",
                    Title = "Asus ROG G752 Gaming Laptop",
                    Url = "https://www.asus.com/vn/ROG-Republic-Of-Gamers/ROG-G752VM/",
                    Source = "/assets/client/ads-example/asus-rog-g752-gaming-laptop.mp4",
                    StartDate = new DateTime(2017, 2, 1),
                    EndDate = new DateTime(2017, 5, 1),
                    AdsLocation = adsLocations.Single(x => x.Name == "Newest")
                },
                new Advertisement
                {
                    Name = "Ford",
                    Description = "Ford",
                    Title = "Ford",
                    Url = "https://www.ford.com.vn/",
                    Source = "/assets/client/ads-example/ford.mp4",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 6, 1),
                    AdsLocation = adsLocations.Single(x => x.Name == "Normal")
                }
            };

            await adsRepository.AddRangeAsync(videoAds);
        }
    }
}