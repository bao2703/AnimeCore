using Microsoft.Extensions.DependencyInjection;
using Services;

namespace AnimeCore.Configuration
{
    public static class TransientConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}