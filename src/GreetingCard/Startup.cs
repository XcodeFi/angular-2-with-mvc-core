using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;
using GreetingCard.Infrastructure;
using Microsoft.EntityFrameworkCore;
using GreetingCard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GreetingCard
{
    public class Startup
    {

        private static string _applicationPath = string.Empty;
        private static string _contentRootPath = string.Empty;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;
            _contentRootPath = env.ContentRootPath;
            // Setup configuration sources.

            var builder = new ConfigurationBuilder()
                .SetBasePath(_contentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // This reads the configuration keys from the secret store.
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GreetingCardContext>(options =>
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<GreetingCardContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication();


            services.AddMvc();


            services.AddLogging();

            // Add session related services.
            services.AddSession();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("http://example.com");
                });
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "ManageStore",
                    authBuilder =>
                    {
                        authBuilder.RequireClaim("ManageStore", "Allowed");
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseFileServer();

            var provider = new PhysicalFileProvider(
                Path.Combine(_contentRootPath, "node_modules")
            );
            var _fileServerOptions = new FileServerOptions();
            _fileServerOptions.RequestPath = "/node_modules";
            _fileServerOptions.StaticFileOptions.FileProvider = provider;
            _fileServerOptions.EnableDirectoryBrowsing = true;
            app.UseFileServer(_fileServerOptions);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                      name: "areaRoute",
                      template: "{area:exists}/{controller}/{action}",
                      defaults: new { action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                //routes.MapRoute(
                //    name: "api",
                //    template: "{controller}/{id?}");

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                //routes.MapWebApiRoute("DefaultApi", "api/{X}/{id?}");
            });
            SampleData.InitializeDatabaseAsync(app.ApplicationServices).Wait();
        }
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
