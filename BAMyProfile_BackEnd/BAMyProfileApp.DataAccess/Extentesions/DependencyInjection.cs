using BAMyProfileApp.DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace BAMyProfileApp.DataAccess.Extentesions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BAMyProfileAppDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString(BAMyProfileAppDbContext.ConnectionName));
            });
            services.AddIdentity<IdentityUser, IdentityRole>(option =>
            {
               
                option.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<BAMyProfileAppDbContext>().AddDefaultTokenProviders();

            
            return services;
        }
    }
}
