﻿using System;
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
            await InitializeBannerAdvertisementAsync(app);
            await unitOfWork.SaveChangesAsync();
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
                    Price = 100000,
                    LocationType = LocationType.Video
                },
                new AdsLocation
                {
                    Name = "Most Liked",
                    Desciption = "Show ads on Most Liked movie",
                    Price = 500000,
                    LocationType = LocationType.Video
                },
                new AdsLocation
                {
                    Name = "Newest",
                    Desciption = "Show ads on Newest movie",
                    Price = 200000,
                    LocationType = LocationType.Video
                },
                new AdsLocation
                {
                    Name = "Normal",
                    Desciption = "Show ads on Normal movie",
                    Price = 200000,
                    LocationType = LocationType.Video
                }
            };

            var customerRepository = app.ApplicationServices.GetService<ICustomerRepository>();

            var customer = new Customer
            {
                Name = "Bảo",
                Email = "bao@gmail.com",
                PhoneNumber = "01223602166",
                Address = "Neptune"
            };

            customerRepository.Add(customer);

            await adsLocationRepository.AddRangeAsync(adsLocations);

            var adsRepository = app.ApplicationServices.GetService<IVideoAdsRepository>();

            var videoAds = new List<VideoAds>
            {
                new VideoAds
                {
                    Name = "Coca-Cola: Coke Mini (Hulk vs. Ant-Man)",
                    Description = "Coca-Cola: Coke Mini (Hulk vs. Ant-Man)",
                    Title = "Coca-Cola: Coke Mini (Hulk vs. Ant-Man)",
                    Url = "http://www.coca-colacompany.com/",
                    Source = "/assets/client/ads-example/coca-cola-coke-mini-hulk-vs-ant-man.mp4",
                    StartDate = new DateTime(2017, 3, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    Price = adsLocations.Single(x => x.Name == "Popular").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Popular"),
                    Customer = customer
                },
                new VideoAds
                {
                    Name = "Eat24",
                    Description = "Eat24",
                    Title = "Eat24",
                    Url = "https://eat24.com/",
                    Source = "/assets/client/ads-example/skip-this-ad.mp4",
                    StartDate = new DateTime(2017, 9, 1),
                    EndDate = new DateTime(2017, 10, 1),
                    Price = adsLocations.Single(x => x.Name == "Popular").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Popular"),
                    Customer = customer
                },
                new VideoAds
                {
                    Name = "2016 Design Innovation 3D Animation",
                    Description = "2016 Design Innovation 3D Animation",
                    Title = "2016 Design Innovation 3D Animation",
                    Url = "https://eat24.com/",
                    Source = "/assets/client/ads-example/2016-design-innovation-3D-animation.mp4",
                    StartDate = new DateTime(2017, 3, 1),
                    EndDate = new DateTime(2017, 10, 1),
                    Price = adsLocations.Single(x => x.Name == "Most Liked").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Most Liked"),
                    Customer = customer
                },
                new VideoAds
                {
                    Name = "Asus ROG G752",
                    Description = "Asus ROG G752",
                    Title = "Asus ROG G752 Gaming Laptop",
                    Url = "https://www.asus.com/vn/ROG-Republic-Of-Gamers/ROG-G752VM/",
                    Source = "/assets/client/ads-example/asus-rog-g752-gaming-laptop.mp4",
                    StartDate = new DateTime(2017, 2, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    Price = adsLocations.Single(x => x.Name == "Newest").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Newest"),
                    Customer = customer
                },
                new VideoAds
                {
                    Name = "Dell Alienware",
                    Description = "Dell Alienware",
                    Title = "Dell Alienware",
                    Url = "http://www.dell.com/en-us/gaming/alienware?cs=19",
                    Source = "/assets/client/ads-example/dell-alienware-17-2016-official-video-trailer-commercial.mp4",
                    StartDate = new DateTime(2017, 3, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    Price = adsLocations.Single(x => x.Name == "Newest").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Newest"),
                    Customer = customer
                },
                new VideoAds
                {
                    Name = "Ford",
                    Description = "Ford",
                    Title = "Ford",
                    Url = "https://www.ford.com.vn/",
                    Source = "/assets/client/ads-example/ford.mp4",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    Price = adsLocations.Single(x => x.Name == "Normal").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Normal"),
                    Customer = customer
                },
                new VideoAds
                {
                    Name = "Expired Ads example",
                    Description = "Expired Ads example",
                    Title = "Expired Ads example",
                    Url = "http://www.localhost.com",
                    Source = "C:/",
                    StartDate = new DateTime(2017, 1, 1),
                    EndDate = new DateTime(2017, 3, 1),
                    Price = adsLocations.Single(x => x.Name == "Newest").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Newest"),
                    Customer = customer
                }
            };

            await adsRepository.AddRangeAsync(videoAds);
        }

        private static async Task InitializeBannerAdvertisementAsync(IApplicationBuilder app)
        {
            var adsLocationRepository = app.ApplicationServices.GetService<IAdsLocationRepository>();

            var adsLocations = new List<AdsLocation>
            {
                new AdsLocation
                {
                    Name = "Top",
                    Desciption = "Show ads on top page",
                    Price = 110000,
                    LocationType = LocationType.Banner
                },
                new AdsLocation
                {
                    Name = "Bottom",
                    Desciption = "Show ads on bottom page",
                    Price = 220000,
                    LocationType = LocationType.Banner
                },
                new AdsLocation
                {
                    Name = "Right 1",
                    Desciption = "Show ads on right page",
                    Price = 250000,
                    LocationType = LocationType.Banner
                },
                new AdsLocation
                {
                    Name = "Right 2",
                    Desciption = "Show ads on right page",
                    Price = 250000,
                    LocationType = LocationType.Banner
                },
                new AdsLocation
                {
                    Name = "Right 3",
                    Desciption = "Show ads on right page",
                    Price = 250000,
                    LocationType = LocationType.Banner
                },
                new AdsLocation
                {
                    Name = "Right Balloon",
                    Desciption = "Show ads on bottom right page",
                    Price = 2500000,
                    LocationType = LocationType.Banner
                }
            };

            await adsLocationRepository.AddRangeAsync(adsLocations);

            var customerRepository = app.ApplicationServices.GetService<ICustomerRepository>();

            var customer = new Customer
            {
                Name = "Bảo2",
                Email = "bao2@gmail.com",
                PhoneNumber = "01223602166",
                Address = "Neptune2"
            };

            customerRepository.Add(customer);

            var adsRepository = app.ApplicationServices.GetService<IBannerAdsRepository>();

            var videoAds = new List<BannerAds>
            {
                new BannerAds
                {
                    Name = "Example",
                    Description = "Example",
                    Title = "Example",
                    Url = "http://localhost.com/",
                    Source = "/assets/client/ads-example/banner/example-top-banner.png",
                    StartDate = new DateTime(2017, 3, 10),
                    EndDate = new DateTime(2017, 7, 10),
                    BannerType = BannerType.Home,
                    Height = "100px",
                    Width = "100%",
                    Price = adsLocations.Single(x => x.Name == "Top").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Top"),
                    Customer = customer
                },
                new BannerAds
                {
                    Name = "C# vs Java",
                    Description = "C# vs Java",
                    Title = "C# vs Java",
                    Url = "http://CsvsJava.com/",
                    Source = "/assets/client/ads-example/banner/c_vs_java_play_the_match.gif",
                    StartDate = new DateTime(2017, 3, 10),
                    EndDate = new DateTime(2017, 7, 10),
                    BannerType = BannerType.Home,
                    Height = "150px",
                    Width = "100%",
                    Price = adsLocations.Single(x => x.Name == "Bottom").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Bottom"),
                    Customer = customer
                },
                new BannerAds
                {
                    Name = "Pepsi",
                    Description = "Pepsi",
                    Title = "Pepsi",
                    Url = "http://www.pepsi.com/",
                    Source = "/assets/client/ads-example/banner/pepsi_halloween.jpg",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    BannerType = BannerType.Home,
                    Price = adsLocations.Single(x => x.Name == "Right 1").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Right 1"),
                    Customer = customer
                },
                new BannerAds
                {
                    Name = "Razer",
                    Description = "Razer",
                    Title = "Razer",
                    Url = "https://www.razerzone.com/store/razer-kraken-71-chroma",
                    Source = "/assets/client/ads-example/banner/razer-kraken-7-1-usb-gaming-headset.jpg",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    BannerType = BannerType.Home,
                    Price = adsLocations.Single(x => x.Name == "Right 2").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Right 2"),
                    Customer = customer
                },
                new BannerAds
                {
                    Name = "Challenge Accepted",
                    Description = "Challenge Accepted",
                    Title = "Challenge Accepted",
                    Url = "https://lerageshirts.com/product/challenge-accepted-meme-rage-face-t-shirt/",
                    Source = "/assets/client/ads-example/banner/challenge-accepted-shirt-meme-rage-face-funny-tee.jpg",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    BannerType = BannerType.Child,
                    Price = adsLocations.Single(x => x.Name == "Right 1").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Right 1"),
                    Customer = customer
                },
                new BannerAds
                {
                    Name = "Buzz Ad Demo",
                    Description = "Buzz Ad Demo",
                    Title = "Buzz Ad Demo",
                    Url = "http://BuzzAdDemo.com",
                    Source = "/assets/client/ads-example/banner/buzz-ad-demo.jpg",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    BannerType = BannerType.HomeChild,
                    Price = adsLocations.Single(x => x.Name == "Right 3").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Right 3"),
                    Customer = customer
                },
                new BannerAds
                {
                    Name = "Steam sale",
                    Description = "Steam sale",
                    Title = "Steam sale",
                    Url = "http://store.steampowered.com/",
                    Source = "/assets/client/ads-example/banner/steam-gaben-sale.gif",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    BannerType = BannerType.HomeChild,
                    Price = adsLocations.Single(x => x.Name == "Right 2").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Right 2"),
                    Customer = customer
                },
                new BannerAds
                {
                    Name = "steelseries",
                    Description = "steelseries",
                    Title = "steelseries",
                    Url = "https://steelseries.com/",
                    Source = "/assets/client/ads-example/banner/steelseries_minimalistic.png",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 7, 1),
                    BannerType = BannerType.HomeChild,
                    Height = "200px",
                    Width = "250px",
                    Price = adsLocations.Single(x => x.Name == "Right Balloon").Price,
                    AdsLocation = adsLocations.Single(x => x.Name == "Right Balloon"),
                    Customer = customer
                }
            };

            await adsRepository.AddRangeAsync(videoAds);
        }
    }
}