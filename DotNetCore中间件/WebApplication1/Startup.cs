using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }





        private static void HandleMap(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Handle Map");
            });
        }

        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            //终端中间件
            //使用Run方法运行一个委托，这就是最简单的中间件，它拦截了所有请求，返回一段文本作为响应。Run委托终止了管道的运行，因此也叫作终端中间件。
            //app.Run(async (context)=> {
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //使用Use方法运行一个委托，我们可以在Next调用之前和之后分别执行自定义的代码，从而可以方便的进行日志记录等工作。这段代码中，使用next.Invoke()方法调用下一个中间件，从而将中间件管道连贯起来；如果不调用next.Invoke()方法，则会造成管道短路。
            app.Use(async(context,next)=> {
                //Do something here

                //Invoke next middleware
                await next.Invoke();

                //Do something here

            });

            //使用Map创建基于路径匹配的分支、使用MapWhen创建基于条件的分支。
            app.Map("/map", HandleMap);

            app.MapWhen(context => context.Request.Query.ContainsKey("branch"),
                       HandleBranch);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            //Map方法还支持层级的分支
            app.Map("/level1", level1App => {
                level1App.Map("/level2a", level2AApp => {
                    // "/level1/level2a" processing
                });
                level1App.Map("/level2b", level2BApp => {
                    // "/level1/level2b" processing
                });
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}
