using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using VS.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net.Repository;
using log4net;
using log4net.Config;
using System.Reflection;

namespace VS.CoreApi
{
    /// <summary>
    /// startup 类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //加载日志配置
            LoggerRepository = LogManager.CreateRepository("BPDM.Logger");
            XmlConfigurator.Configure(LoggerRepository, new FileInfo("Log4net.config"));
        }

        /// <summary>
        /// 配置文件
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 日志仓储
        /// </summary>
        public static ILoggerRepository LoggerRepository { get; set; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

            services.AddMvc(o => {
                //添加异常过滤器
                o.Filters.Add<ExceptionFilter>();
            });

            //日志映射
            services.AddSingleton<ILoggerHelper, LogHelper>();

            #region 权限 jwt配置
            var byteArrayKey = Encoding.ASCII.GetBytes(AppsettingsHelper.GetConfigString("Authorize", "SecurityKey"));
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                ValidIssuer = AppsettingsHelper.GetConfigString("Authorize", "Issuer"),
                ValidAudience = AppsettingsHelper.GetConfigString("Authorize", "Audience"),
                IssuerSigningKey = new SymmetricSecurityKey(byteArrayKey)
            };

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = parameters;
            });
            #endregion

            #region Swagger接口文档
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Info()
                {
                    Contact = new Contact() { Email = "info@bpdm.com.cn", Name = "BPDM", Url = "www.bpdm.com" },
                    Description ="提供总值，波形，频谱等json格式数据",
                    Title= "BPDM 接口文档",
                    Version ="v1",
                });
                
                var xmlPath = Path.Combine(basePath, "VS.CoreApi.xml");
                o.IncludeXmlComments(xmlPath);
            });

            #endregion

            #region Autofac
            ContainerBuilder builder = new ContainerBuilder();
            var servicesDllFile = Path.Combine(basePath, "Vs.Service.dll");
            var assemblysServices = Assembly.LoadFile(servicesDllFile);//直接采用加载文件的方法

            //repository service 做映射
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();

            var repositoryDllFile = Path.Combine(basePath, "Vs.Repository.dll");
            var assemblysRepository = Assembly.LoadFile(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

            builder.Populate(services);
            IContainer container = builder.Build();

            //autofac 替换自带IOC
            return new AutofacServiceProvider(container);
            #endregion
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseAuthentication();

            app.UseMvc(); //注意UserMvc 要在最后一行

        }
    }
}
