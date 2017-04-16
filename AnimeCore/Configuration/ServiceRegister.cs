using AnimeCore.Common;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;

namespace AnimeCore.Configuration
{
    public static class ServiceRegister
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IVideoAdsRepository, VideoAdsRepository>();
            services.AddTransient<IVideoAdsLocationRepository, VideoAdsLocationRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddSingleton<Helper>();
        }
    }
}