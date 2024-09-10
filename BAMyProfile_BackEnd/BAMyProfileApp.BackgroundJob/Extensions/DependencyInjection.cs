using BAMyProfileApp.DataAccess.Contexts;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.BackgroundJob.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBackgroundJobServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Hangfire Dependency
            services.AddHangfire(cfg => cfg
                                            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                                            .UseSimpleAssemblyNameTypeSerializer()
                                            .UseRecommendedSerializerSettings()
                                            .UseSqlServerStorage(configuration.GetConnectionString(BAMyProfileAppDbContext.ConnectionName)));

            services.AddHangfireServer();
            //backgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));
            return services;
        }
    }
}
