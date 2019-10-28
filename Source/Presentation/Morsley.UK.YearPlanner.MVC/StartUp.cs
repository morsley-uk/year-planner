using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Morsley.UK.YearPlanner.MVC
{
    public class StartUp
    {
        public IConfiguration Configuration { get; }

        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencyInjection(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigurePipeline(app, env);
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        private void ConfigurePipeline(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Planner}/{action=Year}/{value?}");
            });
        }
    }
}