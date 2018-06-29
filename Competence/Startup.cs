using System;
using CompanyData.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Reflection;


namespace Competence
{
    /// <summary>
    /// Start up class that runs when the program is started
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Start up constructor that takes the IConfiguration interface as a parameter
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Object of IConfiguration interface
        /// </summary>
        public IConfiguration Configuration { get; }



        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<CompanyDBContext>(options =>
            options.UseSqlServer(Configuration["Data:CompanyConnectionString:CompanyConnection"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration["Data:IdentityConnectionString:IdentityConnection"]));

            services.AddSingleton(Configuration);

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options => options.ResourcesPath = "Resources")
              .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(
        opts =>
        {
            var supportedCultures = new []
            {
                        new CultureInfo("en-GB"), // English
                        new CultureInfo("sv-SE"), //Swedish
                        new CultureInfo("nb-NO"), //Norwegian Bokmål
                        new CultureInfo("fi-FI"), //Finnish
                        new CultureInfo("da-DK"), //Danish
                        new CultureInfo("fr-FR"), //French
                        new CultureInfo("de-DE"), //German
                        new CultureInfo("es-ES"), //Spanish
            };

            opts.DefaultRequestCulture = new RequestCulture(culture:"en-GB");
            // Formatting numbers, dates, etc.
            opts.SupportedCultures = supportedCultures;
            // UI strings that we have localized.
            opts.SupportedUICultures = supportedCultures;
            //var provider = new CookieRequestCultureProvider()
            //{
            //    CookieName = "Preferences"
            //};
            //opts.RequestCultureProviders.Insert(0, provider);
        });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireUserLoginAccess", policy => policy.RequireRole("User"));
                options.AddPolicy("RequireAdminAccess", policy => policy.RequireRole("Admin"));
            });

            services.AddMemoryCache();
            services.AddSession();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            // Add the custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManger = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            // Roles in the application
            string[] roleNames = { "Admin", "User" };

            IdentityResult roleResult;
           
            foreach (var roleName in roleNames)
            {
                // Create the roles and seed them to the db
                var roleExists = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }             
            }

            // Create the super admin
            var powerUser = new IdentityUser
            {
                UserName = Configuration.GetSection("Data:AdminSettings")["SuperAdminName"],
            };

           

            string adminPassword = Configuration.GetSection("Data:AdminSettings")["SuperAdminPassword"];
            var _user = await UserManger.FindByNameAsync(Configuration.GetSection("Data:AdminSettings")["SuperAdminName"]);

            if (_user == null)
            {
                var createSuperUser = await UserManger.CreateAsync(powerUser, adminPassword);
                if (createSuperUser.Succeeded)
                {
                    // Give the new user admin role
                    await UserManger.AddToRoleAsync(powerUser, "Admin");
                }
            }

            // Create the user
            var normalUser = new IdentityUser
            {
                UserName = Configuration.GetSection("Data:UserSettings")["UserName"],
            };

            string userPassword = Configuration.GetSection("Data:UserSettings")["UserPassword"];
            var _normalUser = await UserManger.FindByNameAsync(Configuration.GetSection("Data:UserSettings")["UserName"]);

            if (_normalUser == null)
            {
                var createUser = await UserManger.CreateAsync(normalUser, userPassword);
                if (createUser.Succeeded)
                {
                    // Give the new user a role
                    await UserManger.AddToRoleAsync(normalUser, "User");
                }
            }
        }

        /// <summary>
        /// This method gets called by the runtime. 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="serviceProvider"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            try
            {   //Create Identity Database on first start up if not already exists
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<AppIdentityDbContext>().Database.Migrate();
                   
                }
            }
            catch (Exception ex)
            {
              
               Console.Write(ex);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            
            app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
            

            app.UseAuthentication();           
            app.UseStaticFiles();
            app.UseSession();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Companies}/{action=HomePageAsync}/{id?}");
            });
            CreateRoles(serviceProvider).Wait();

        }
    }
}
