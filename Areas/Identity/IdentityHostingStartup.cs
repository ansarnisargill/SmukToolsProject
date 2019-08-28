using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmukToolsApp.Areas.Identity.Data;
using SmukToolsApp.Models;

[assembly: HostingStartup(typeof(SmukToolsApp.Areas.Identity.IdentityHostingStartup))]
namespace SmukToolsApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SmukToolsAppContext>(options =>
                    //options.UseSqlServer(
                    //    context.Configuration.GetConnectionString("SmukToolsAppContextConnection")
                    options.UseInMemoryDatabase("IdentityDB"));

                services.AddDefaultIdentity<SmukToolsAppUser>()
                    .AddEntityFrameworkStores<SmukToolsAppContext>();
            });
        }
    }
}