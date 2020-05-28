using CrowdFundingCore.Database;
using CrowdFundingCore.Models;
using CrowdFundingCore.Services;
using CrowdFundingCore.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CrowdFundingMVC
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

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddDbContext<CrFrDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddDefaultIdentity<MyUsers>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddRoles<IdentityRole>()
                 .AddDefaultTokenProviders()
                 .AddDefaultUI()
                 .AddEntityFrameworkStores<CrFrDbContext>();

            //we use this to get current user's details
            services.AddHttpContextAccessor();


            services.AddDbContext<CrFrDbContext>(options => options.UseSqlServer(CrFrDbContext.connectionString));
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<IPledgeServices, PledgeServices>();
            services.AddScoped<IPostServices, PostServices>();
            //services.AddTransient<IProjectManager, ProjectManagement>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsHeadersAndMethods",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();

            });

            services.AddControllersWithViews();
            services.AddLogging();
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
          //  app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAllOriginsHeadersAndMethods");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseBrowserLink();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}