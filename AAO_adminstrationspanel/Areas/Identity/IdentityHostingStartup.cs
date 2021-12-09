using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AAO_adminstrationspanel.Data;
using AAO_adminstrationspanel.Models;

[assembly: HostingStartup(typeof(AAO_adminstrationspanel.Areas.Identity.IdentityHostingStartup))]
namespace AAO_adminstrationspanel.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AAO_adminstrationspanelContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AAO_adminstrationspanelContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AAO_adminstrationspanelContext>();
            });
        }
    }
}