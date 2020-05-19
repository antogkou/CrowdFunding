using CrowdFundingCH.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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

                services.AddMvc(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                }).AddXmlDataContractSerializerFormatters();

            });
        }
    }
}