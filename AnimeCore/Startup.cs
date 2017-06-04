using AnimeCore.Common;
using AnimeCore.Configuration;
using AnimeCore.DataInitializer;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
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
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //const string connection = "DefaultConnection";
            //const string connection = "AzureConnection";

            services.AddDbContext<NeptuneContext>(options =>
            {
                options.UseSqlite("Data Source=neptune.db");
                //options.UseSqlServer(Configuration.GetConnectionString(connection));
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<Authentication>(Configuration.GetSection("Authentication"));

            services.Configure<FormOptions>(options => { options.MultipartBodyLengthLimit = 500000000; });

            services.AddMvc()
                .AddJsonOptions(
                    options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });

            IdentityConfiguration.Configure(services);
            ServiceRegister.Configure(services);
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStatusCodePagesWithRedirects("/Error/{0}");

            app.UseStaticFiles();

            app.UseIdentity();

            var authentication = app.ApplicationServices.GetService<IOptionsSnapshot<Authentication>>().Value;

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

            if (env.IsDevelopment())
            {
                await DataSeeder.InitializeAsync(app);
            }
        }
    }
}