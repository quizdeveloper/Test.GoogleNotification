using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.GoogleNotification.Bsl.NotifyHistory;
using Test.GoogleNotification.Bsl.User;
using Test.GoogleNotification.Dal.Entities;
using Test.GoogleNotification.Dal.NotifyHistory;
using Test.GoogleNotification.Dal.Users;

namespace Test.GoogleNotification.App
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
            // Add EF connection
            services.AddDbContextPool<GoogleNotificationContext>(x=> {
                x.UseMySQL(Configuration.GetConnectionString("GoogleNotifyConnectionString"));
            });

            // Add IoC
            services.AddScoped<IUserBsl, UserBsl>();
            services.AddTransient<IUserDal, UserDal>();
            services.AddScoped<INotifyHistoryBsl, NotifyHistoryBsl>();
            services.AddTransient<INotifyHistoryDal, NotifyHistoryDal>();
            services.AddTransient<GoogleNotificationContext>();

            services.AddControllersWithViews();
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
