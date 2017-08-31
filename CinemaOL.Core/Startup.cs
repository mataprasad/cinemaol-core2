using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CinemaOL.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authentication;


namespace CinemaOL.Core
{
    public class Startup
    {
        private string _contentRootPath = null;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this._contentRootPath = env.ContentRootPath;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<GlobalOption>(O =>
            {
                O.DefaultConnectionString = Configuration.GetConnectionString("DefaultConnection");
                O.ContentRootPath = this._contentRootPath;
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc().AddXmlDataContractSerializerFormatters();


            //services.AddAuthentication("MyCookieAuthenticationScheme")
            services.AddAuthentication(o =>
            {

                o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            })
            .AddCookie(options =>
             {
                 options.AccessDeniedPath = "/Public/Login";
                 options.LoginPath = "/Public/Login";

             });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CasualUser", policy => policy.RequireAuthenticatedUser());
                options.AddPolicy("Admin", policy => policy.RequireAuthenticatedUser().RequireRole("Admin"));
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSession();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Public}/{action=Index}/{id?}");
            });
        }
    }
}
