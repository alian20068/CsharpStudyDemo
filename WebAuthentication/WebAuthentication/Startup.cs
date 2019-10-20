using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebAuthentication
{
    public class Startup
    {
        private static readonly string swaggerDocName = "v1";
        public void ConfigureServices(IServiceCollection services)
        {
            //注册Swagger生成器，定义一个或多个Swagger文档
            services.AddSwaggerGen(p => {
                p.SwaggerDoc(swaggerDocName, new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "My Authentication Demo",
                    Version = "1.0.0",
                    Description = "身份验证示例",
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

            //启用Swagger
            app.UseSwagger();
            app.UseSwaggerUI(p => {
                p.SwaggerEndpoint(
                    $"../swagger/{swaggerDocName}/swagger.json",
                    "My API v1.0.0"
                );
            });

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */
        }
    }
}
