using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiddywee.BLL.Core;
using Kiddywee.BLL.Interfaces;
using Kiddywee.BLL.Repositories;
using Kiddywee.Core;
using Kiddywee.DAL.Data;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.HttpOverrides;

namespace Kiddywee
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
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

           
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.ForwardLimit = 2;
                options.ForwardedForHeaderName = "X-Forwarded-For";
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddDbContext<FileDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("FileConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ExternalScheme;

            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
                {

                    option.LoginPath = "/account/login";
                    option.AccessDeniedPath = "/account/accessdenied";
                    option.ExpireTimeSpan = TimeSpan.FromDays(30);
                });
            services.AddRouting(options => options.LowercaseUrls = true);

     


            services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
            services.AddMvc(o => 
                { 
                    o.EnableEndpointRouting = false;
                    o.Filters.Add(typeof(CustomFilter));
                }
            );

            services.AddTransient<IEmailSender, EmailSender>(); 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaims>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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
