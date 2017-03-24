using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.DataInitializer
{
    public static class Seeder
    {
        public static void Seed(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<NeptuneContext>();



            context.SaveChanges();
        }
    }
}