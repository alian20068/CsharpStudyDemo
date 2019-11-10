using AuthenticationDemo.Authentication;
using AuthenticationDemo.Extensions;
using AuthenticationDemo.Security.Session;
using AuthenticationDemo.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //ASP.NET Core 2.2 之后的版本，必须添加此代码才能注入IHttpContextAccessor实例
            services.AddHttpContextAccessor();
            //添加依赖注入规则
            services.AddScoped<IClaimsSession, ClaimsSession>();
            services.AddScoped<IAuthenticationService, SampleAuthenticationService>();
            //添加身份验证
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = BearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = BearerDefaults.AuthenticationScheme;
            }).AddBearer();

            //注册Swagger生成器，定义一个或多个Swagger文档
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "My API 文档",
                    Version = "1.0.0",
                    Description = "使用Swagger示例",
                    //可定义作者、许可证等
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //应用身份验证
            app.UseAuthentication();

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */

            //允许中间件为Json端点服务生成Swagger
            app.UseSwagger();
            //使中间件能够服务于轻量级用户界面，并指定Swagger Json 端点
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
                //在应用程序根处提供Swagger UI
                options.RoutePrefix = string.Empty;
            });

        }
    }
}
