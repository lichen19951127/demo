using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //IsDevelopment方法大家已经知道了, 判断当前是不是开发环境.
            //IsProduction方法, 判断当前是不是运营(正式)环境
            //IsStaging方法, 判断当前是不是预运行环境
            //IsEnvironment方法, 根据传入的环境名称, 判断是不是当前环境类型(用于自定义环境判断)
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler();
            }
            //欢迎页
            //app.UseWelcomePage();
            //配置路径
            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/welcome"
            });

            //next=>RequestDelegate 
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        if (context.Request.Path.StartsWithSegments("/first"))
            //        {
            //            await context.Response.WriteAsync("First");
            //        }
            //        else
            //        {
            //            await next(context);
            //        }
            //    };
            //});

            app.Run(async (context) =>
            {
                throw new Exception();
                var msg = "123";
                await context.Response.WriteAsync(msg);
            });
            //env.EnvironmentName = "Cus1";    //设置自定义环境名称
            //env.EnvironmentName = "Staging";    //设置预发布环境
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain;charset=utf-8";  //防止WriteAsync方法输出中文乱码
                if (env.IsDevelopment())
                {
                    //Debug
                    await context.Response.WriteAsync("开发环境", Encoding.UTF8);
                }
                else if (env.IsProduction())
                {
                    //切换Release
                    await context.Response.WriteAsync("运营环境", Encoding.UTF8);
                }
                else if (env.IsStaging())
                {
                    await context.Response.WriteAsync("预发布环境", Encoding.UTF8);
                }
                else
                {
                    //await context.Response.WriteAsync("自定义环境", Encoding.UTF8);
                    if (env.IsEnvironment("Cus"))
                    {
                        await context.Response.WriteAsync("自定义环境: Cus", Encoding.UTF8);
                    }
                    else if (env.IsEnvironment("Cus1"))
                    {
                        await context.Response.WriteAsync("自定义环境: Cus1", Encoding.UTF8);
                    }
                    else
                    {
                        await context.Response.WriteAsync($"自定义环境: {env.EnvironmentName}", Encoding.UTF8);
                    }
                }
            });
        }
    }
}
