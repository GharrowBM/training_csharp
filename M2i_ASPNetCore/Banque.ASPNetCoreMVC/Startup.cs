using Banque.ASPNetCoreMVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banque.ASPNetCoreMVC
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
            services.AddTransient<ToolsService>(); 
            services.AddTransient<CheckService>();
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
                    name: "bankEditClient",
                    pattern: "bank/client/edit/{id}",
                    defaults: new { controller = "Bank", action = "EditClient" });

                endpoints.MapControllerRoute(
                    name: "bankRemoveClient",
                    pattern: "bank/client/remove/{id}",
                    defaults: new { controller = "Bank", action = "RemoveClient" });

                endpoints.MapControllerRoute(
                    name: "bankNewClient",
                    pattern: "bank/client/new",
                    defaults: new { controller = "Bank", action = "NewClient" });

                endpoints.MapControllerRoute(
                    name: "bankNewAccount",
                    pattern: "bank/account/new",
                    defaults: new { controller = "Bank", action = "NewAccount" });

                endpoints.MapControllerRoute(
                    name: "bankIndex",
                    pattern: "bank",
                    defaults: new { controller="Bank", action="Index"});

                endpoints.MapControllerRoute(
                    name: "checkPass",
                    pattern: "check/pass/{s}",
                    defaults: new { controller = "Chuck", action = "CheckPass" });

                endpoints.MapControllerRoute(
                    name: "getChucked",
                    pattern: "getchucked/{s}",
                    defaults: new { controller = "Chuck", action = "Chucked" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
