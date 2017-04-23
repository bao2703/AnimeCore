using AnimeCore.Common;
using AnimeCore.Configuration;
using AnimeCore.DataInitializer;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AnimeCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NeptuneContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<Authentication>(Configuration.GetSection("Authentication"));

            services.AddMvc()
                .AddJsonOptions(
                    options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

            services.AddAuthorization(options =>
                options.AddPolicy("User", policy => policy.RequireClaim("User"))
            );

            IdentityConfiguration.Configure(services);
            ServiceRegister.Configure(services);
            PagerConfiguration.Configure(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            var authentication = app.ApplicationServices.GetService<IOptions<Authentication>>().Value;

            app.UseFacebookAuthentication(new FacebookOptions
            {
                AppId = authentication.Facebook.AppId,
                AppSecret = authentication.Facebook.AppSecret
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "admin",
                    "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            await DataSeeder.InitializeAsync(app);
        }
    }
}