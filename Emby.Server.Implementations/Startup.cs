using System;
using System.Linq;
using System.Reflection;
using MediaBrowser.Api;
using MediaBrowser.Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceStack;

namespace Emby.Server.Implementations
{
    public class Startup : IStartup
    {
        private readonly Assembly[] _assemblies;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, Assembly[] assemblies)
        {
            Configuration = configuration;
            _assemblies = assemblies.Distinct().ToArray();
        }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetService<IHostingEnvironment>();
            var loggerFactory = app.ApplicationServices.GetService<ILoggerFactory>();

            // loggerFactory.AddProvider(new SerilogLoggerProvider());

            //Register your ServiceStack AppHost as a .NET Core module
            var type = typeof(BaseApiService);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) || type.IsAssignableFrom(typeof(BaseApiService)))
                .Select(s => s.Assembly)
                .Distinct().Concat(new [] {typeof(IServerApplicationHost).Assembly});

            

            app.UseServiceStack(new ServiceStackAppHost("JellyfinServer", _assemblies.ToList().Concat(new[] { typeof(IServerApplicationHost).Assembly }).ToArray())
            {
                AppSettings = new NetCoreAppSettings(Configuration) // Use **appsettings.json** and config sources
            });


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }

}
