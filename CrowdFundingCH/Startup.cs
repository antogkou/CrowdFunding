using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Controllers;
using CrowdFundingCH.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace CrowdFundingCH
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CrowdFundingDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CrowdFundingDBContextConnection")));

            services.AddDefaultIdentity<AllUsers>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<CrowdFundingDBContext>();

          //  services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IProjectManager, ProjectManagement>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



            services.AddControllersWithViews();
            services.AddRazorPages();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
