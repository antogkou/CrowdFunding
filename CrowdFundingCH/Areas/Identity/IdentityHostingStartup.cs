using System;
using CrowdFundingCH.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CrowdFundingCH.Areas.Identity.IdentityHostingStartup))]
namespace CrowdFundingCH.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CrowdFundingDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CrowdFundingDBContextConnection")));

                
                //works
                //services.AddDefaultIdentity<AllUsers>()
                //    .AddRoles<IdentityRole>()
                //    .AddEntityFrameworkStores<CrowdFundingDBContext>();

                //services.AddDefaultIdentity<AllUsers>(options => options.SignIn.RequireConfirmedAccount = false)
                //    .AddEntityFrameworkStores<CrowdFundingDBContext>();

                services.AddMvc(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                }).AddXmlDataContractSerializerFormatters();

                //services.AddAuthorization(options =>
                //{
                //    options.AddPolicy("RequireAdministratorRole",
                //         policy => policy.RequireRole("Administrator"));
                //});

            });
        }
    }
}