using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// IHostingEnvironment 服务用于获取当前环境
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            //Configuration = configuration;
            //在Development环境中，AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)将会查找appsettings.Development.json配置文件，并覆盖appsettings.json中存在的值。同样环境变量也会覆盖它们两个的值。

            //一旦将指定文件作为配置源，就可以选择当文件发生变化后，是否重新再付这部分的配置，reloadOnChange: true。
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:true);

            //配置环境变量
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
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

            services.AddOptions();//提供依赖注入

   //当通过绑定选项来配置选项类型的每一个属性时，实际上是绑定到每一个配置键。配置键是大小写不敏感的。

 　　//当通过调用services.Configure<AppSettingOptions>(Configuration); 代码，将一个IConfigureOptions<AppSettingOptions> 服务加入服务容器，是为了后面应用程序或框架能通过IOptions<AppSettingOptions> 服务来获取配置。若想从其他途径（从数据库通过EF获取）获取配置，可以使用ConfigureOptions<TOptions> 扩展方法直接指定经过定制的IConfigureOptions<TOptions>服务。

               services.Configure<AppSettingOptions>(Configuration); //绑定配置选项   

            ////通过代码编写
            //services.Configure<AppSettingOptions>(options =>
            //{
            //    options.AllowedHosts = "test";
            //});
            ////只配置部分
            //services.Configure<AppSettingOptions>(Configuration.GetSection("ConnectionStrings"));


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
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=test}/{action=Index}/{id?}");
            });
        }
    }
}
