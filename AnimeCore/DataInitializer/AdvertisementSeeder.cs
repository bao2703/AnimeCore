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
            await InitializeAdvertisementAsync(app);
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

        private static async Task InitializeAdvertisementAsync(IApplicationBuilder app)
        {
            var adsLocationRepository = app.ApplicationServices.GetService<IAdsLocationRepository>();

            var adsLocations = new List<AdsLocation>
            {
                new AdsLocation
                {
                    Name = "Top Banner",
                    Desciption = "Top Banner"
                },
                new AdsLocation
                {
                    Name = "Center Banner",
                    Desciption = "Center Banner"
                },
                new AdsLocation
                {
                    Name = "Footer Banner",
                    Desciption = "Footer Banner"
                },
                new AdsLocation
                {
                    Name = "Right Vertical Banner 1",
                    Desciption = "Right Vertical Banner 1"
                },
                new AdsLocation
                {
                    Name = "Right Vertical Banner 2",
                    Desciption = "Right Vertical Banner 2"
                },
                new AdsLocation
                {
                    Name = "Popular video",
                    Desciption = "Popular video"
                },
                new AdsLocation
                {
                    Name = "Newest video",
                    Desciption = "Newest video"
                }
            };

            await adsLocationRepository.AddRangeAsync(adsLocations);

            var videoAdsRepository = app.ApplicationServices.GetService<IVideoAdsRepository>();

            var videoAds = new List<VideoAds>
            {
                new VideoAds
                {
                    Name = "Neptune",
                    Description = "Neptune",
                    Title = "Neptune",
                    Url = "123123",
                    VideoUrl = "123123",
                    AdsLocation = adsLocations.Single(x => x.Name == "Popular video")
                }
            };

            await videoAdsRepository.AddRangeAsync(videoAds);
        }
    }
}