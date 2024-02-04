using MazOrganization.Data;
using MazOrganization.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersianTranslation.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazOrganization
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
            services.AddControllersWithViews();

            #region DbContext

            
            services.AddDbContext<MazgroupContext>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-E3AGMNR;Initial Catalog=MazGroupPanel;Integrated Security=True; TrustServerCertificate=True;");
            });


            //services.AddDbContext<MazgroupContext>(options =>
            //{
            //    options.UseSqlServer("Server=.; Initial Catalog= mazegrou_;User ID=masefdfskl;Password=j71Sxr26?j71Sxr26?;MultipleActiveResultSets=true;");
            //});


            #endregion




            #region IOC

            services.AddScoped<IProject, ProjectRepository>();
           
            services.AddScoped<IPersonInfo, PersonInfoRepository>();
            services.AddScoped<IFieldInfo, FieldInfoRepository>();
            services.AddScoped<IReferrals, ReferralsRepository>();
            services.AddScoped<ILog, LogRepository>();
            services.AddScoped<IProjectFile, ProjectFileRepository>();
            services.AddScoped<IFinancial, FinancialRepository>();
            services.AddScoped<IReport, ReportRepository>();
            services.AddScoped<IAccounting, AccountingRepository>();


            #endregion

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.SlidingExpiration = true;
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;

            })
                .AddEntityFrameworkStores<MazgroupContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<PersianIdentityErrorDescriber>();

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
            });
        }
    }
}
