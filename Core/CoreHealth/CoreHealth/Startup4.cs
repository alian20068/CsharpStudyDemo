using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace CoreHealth
{
    public class Startup4
    {
        public Startup4(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //健康检查
            services.AddHealthChecks()
                .AddCheck<DatabaseHealthCheck>("sql");
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //健康检查
            app.UseRouting().UseEndpoints(config =>
            {
                config.MapHealthChecks("/health", new HealthCheckOptions
                {
                    //自定义输出
                    ResponseWriter = CustomResponseWriter
                });
            });
        }

        private static Task CustomResponseWriter(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json";

            var result = JsonConvert.SerializeObject(new
            {
                status = healthReport.Status.ToString(),
                errors = healthReport.Entries.Select(p => new
                {
                    key = p.Key,
                    value = p.Value.Status.ToString()
                })
            });

            return context.Response.WriteAsync(result);
        }
    }
}
