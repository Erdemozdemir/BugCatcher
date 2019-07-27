using BugCatcher.BusinessLayer.Managers;
using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.DataAccessLayer;
using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;
using BugCatcher.UI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BugCatcher.UI
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

            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties.
                options.FormFieldName = "__RequestVerificationToken";
                options.HeaderName = "X-CSRF";
                options.SuppressXFrameOptionsHeader = false;
            });

            //services.AddDbContext<DatabaseContext>(opt=>opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<DatabaseContext>();
            services.AddIdentity<UserEntity, IdentityRole>(options =>
                                {
                                    options.Password.RequiredLength = 5;
                                    options.Password.RequireNonAlphanumeric = false;
                                    options.Password.RequireUppercase = false;
                                    options.Password.RequireLowercase = false;

                                    options.User.RequireUniqueEmail = true;
                                    options.User.AllowedUserNameCharacters = "abcçdefghıijklmnoöprsştuüvyz ";
                                })
                                .AddEntityFrameworkStores<DatabaseContext>()
                                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(opt => opt.LoginPath = "/Admin/Login");
            services.ConfigureApplicationCookie(opt => opt.LogoutPath = "/Home/Index");

            services.AddSingleton<ILogRepository, EfLogRepository>();
            services.AddSingleton<IUserRepository, EfUserRepository>();
            services.AddTransient<IItemRepository, EfItemRepository>();
            services.AddTransient<IQueryRepository, EfQueryRepository>();
            services.AddTransient<ICommentRepository, EfCommentRepository>();
            services.AddTransient<IItemFileRepository, EfItemFileRepository>();
            services.AddTransient<IItemSubscriberRepository, EfItemSubcribersRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "itemDetail",
                    template: "{title}/{id}",
                    defaults: new { controller = "Item", action = "Edit" });

                routes.MapRoute(
                    name: "Bugs",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "addSubs",
                    template: "addSubs/{itemId}/{userId}",
                    defaults: new { controller = "Item", action = "AddSubs" });

                routes.MapRoute(
                    name: "addRole",
                    template: "addRole/{userId}/{RoleName}",
                    defaults: new { controller = "Admin", action = "AddRole" });

                routes.MapRoute(
                    name: "DeleteUserRole",
                    template: "deleteUserRole/{userId}/{RoleName}",
                    defaults: new { controller = "Admin", action = "DeleteUserRole" });

                routes.MapRoute(
                    name: "deleteFileOrComment",
                    template: "deleteFileOrComment/{id?}/{isFile?}",
                    defaults: new { controller = "Item", action = "DeleteFileOrComment" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });

            SeedData.Seed(app);
        }
    }
}
