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
            await InitializeBannerAdvertisementAsync(app);
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
                    Address = "Neptune",
                    Invoices = new List<Invoice>
                    {
                        new Invoice
                        {
                            TotalPrice = 50
                        },
                        new Invoice
                        {
                            TotalPrice = 60
                        }
                    }
                },
                new Customer
                {
                    Name = "Bảo2",
                    Email = "bao2@gmail.com",
                    Address = "Neptune",
                    Invoices = new List<Invoice>
                    {
                        new Invoice
                        {
                            TotalPrice = 40
                        },
                        new Invoice
                        {
                            TotalPrice = 10
                        }
                    }
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
                    Name = "Popular",
                    Desciption = "Show ads on Popular movie",
                    Price = 100000
                },
                new VideoAdsLocation
                {
                    Name = "Newest",
                    Desciption = "Show ads on Newest movie",
                    Price = 200000
                },
                new VideoAdsLocation
                {
                    Name = "Normal",
                    Desciption = "Show ads on Normal movie",
                    Price = 200000
                }
            };

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
                    EndDate = new DateTime(2017, 5, 1),
                    VideoAdsLocation = adsLocations.Single(x => x.Name == "Popular")
                },
                new VideoAds
                {
                    Name = "Asus ROG G752",
                    Description = "Asus ROG G752",
                    Title = "Asus ROG G752 Gaming Laptop",
                    Url = "https://www.asus.com/vn/ROG-Republic-Of-Gamers/ROG-G752VM/",
                    Source = "/assets/client/ads-example/asus-rog-g752-gaming-laptop.mp4",
                    StartDate = new DateTime(2017, 2, 1),
                    EndDate = new DateTime(2017, 5, 1),
                    VideoAdsLocation = adsLocations.Single(x => x.Name == "Newest")
                },
                new VideoAds
                {
                    Name = "Dell Alienware",
                    Description = "Dell Alienware",
                    Title = "Dell Alienware",
                    Url = "http://www.dell.com/en-us/gaming/alienware?cs=19",
                    Source = "/assets/client/ads-example/dell-alienware-17-2016-official-video-trailer-commercial.mp4",
                    StartDate = new DateTime(2017, 3, 1),
                    EndDate = new DateTime(2017, 5, 1),
                    VideoAdsLocation = adsLocations.Single(x => x.Name == "Newest")
                },
                new VideoAds
                {
                    Name = "Ford",
                    Description = "Ford",
                    Title = "Ford",
                    Url = "https://www.ford.com.vn/",
                    Source = "/assets/client/ads-example/ford.mp4",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 6, 1),
                    VideoAdsLocation = adsLocations.Single(x => x.Name == "Normal")
                },
                new VideoAds
                {
                    Name = "Expired Ads example",
                    Description = "Expired Ads example",
                    Title = "Expired Ads example",
                    Url = "http://www.localhost.com",
                    Source = "C:/",
                    StartDate = new DateTime(2017, 1, 1),
                    EndDate = new DateTime(2017, 2, 1),
                    VideoAdsLocation = adsLocations.Single(x => x.Name == "Newest")
                }
            };

            await adsRepository.AddRangeAsync(videoAds);
        }

        private static async Task InitializeBannerAdvertisementAsync(IApplicationBuilder app)
        {
            var adsLocationRepository = app.ApplicationServices.GetService<IBannerAdsLocationRepository>();

            var adsLocations = new List<BannerAdsLocation>
            {
                new BannerAdsLocation
                {
                    Name = "Top",
                    Desciption = "Show ads on top page",
                    Price = 110000
                },
                new BannerAdsLocation
                {
                    Name = "Bottom",
                    Desciption = "Show ads on bottom page",
                    Price = 220000
                },
                new BannerAdsLocation
                {
                    Name = "Right",
                    Desciption = "Show ads on right side page",
                    Price = 250000
                }
            };

            await adsLocationRepository.AddRangeAsync(adsLocations);

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
                    EndDate = new DateTime(2017, 5, 10),
                    LocationType = LocationType.Home,
                    Height = "100px",
                    BannerAdsLocation = adsLocations.Single(x => x.Name == "Top")
                },
                new BannerAds
                {
                    Name = "Pepsi",
                    Description = "Pepsi",
                    Title = "Pepsi",
                    Url = "http://www.pepsi.com/",
                    Source = "/assets/client/ads-example/banner/pepsi_halloween.jpg",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 5, 1),
                    LocationType = LocationType.Home,
                    BannerAdsLocation = adsLocations.Single(x => x.Name == "Right")
                },
                new BannerAds
                {
                    Name = "Razer",
                    Description = "Razer",
                    Title = "Razer",
                    Url = "https://www.razerzone.com/store/razer-kraken-71-chroma",
                    Source = "/assets/client/ads-example/banner/razer-kraken-7-1-usb-gaming-headset.jpg",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 5, 1),
                    LocationType = LocationType.Home,
                    BannerAdsLocation = adsLocations.Single(x => x.Name == "Right")
                },
                new BannerAds
                {
                    Name = "steelseries",
                    Description = "steelseries",
                    Title = "steelseries",
                    Url = "https://steelseries.com/",
                    Source = "/assets/client/ads-example/banner/steelseries_minimalistic.png",
                    StartDate = new DateTime(2017, 4, 1),
                    EndDate = new DateTime(2017, 5, 1),
                    BannerAdsLocation = adsLocations.Single(x => x.Name == "Right")
                }
            };

            await adsRepository.AddRangeAsync(videoAds);
        }
    }
}