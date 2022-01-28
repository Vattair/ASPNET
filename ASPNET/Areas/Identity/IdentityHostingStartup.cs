using System;
using ASPNET.Areas.Identity.Data;
using ASPNET.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASPNET.Areas.Identity.IdentityHostingStartup))]
namespace ASPNET.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ASPNETContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ASPNETContextConnection")));

                services.AddDefaultIdentity<ASPNETUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<ASPNETContext>();
            });
        }
    }
}