using Microsoft.Extensions.DependencyInjection;
using Sakura.AspNetCore.Mvc;

namespace AnimeCore.Configuration
{
    public static class PagerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddBootstrapPagerGenerator(options =>
            {
                options.ConfigureDefault();
                options.ItemOptions.Default.Link = PagerItemLinkGenerators.QueryName("pageIndex");
                options.PagerItemsForEndings = 2;
            });
        }
    }
}
