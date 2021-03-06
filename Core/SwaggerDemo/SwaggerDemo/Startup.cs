﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace SwaggerDemo
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ////注册Swagger生成器，定义一个或多个Swagger文档
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "My API 文档",
                    Version = "1.0.0",
                    Description = "使用Swagger示例",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Email = "newjoin@foxmail.com", Name = "NewJoin", Url = "http://www.baidu.com/" },
                    //可定义许可证等
                });

                //要显示注释，须输出 bin\Debug\netcoreapp2.2\SwaggerDemo.xml
                //获取应用程序目录
                var bathPath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmlPath = Path.Combine(bathPath, "SwaggerDemo.xml");
                //启用XML注释
                options.IncludeXmlComments(xmlPath);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

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
