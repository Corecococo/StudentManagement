using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentManagement.Models;

namespace StudentManagement
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //注册MVC
            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();

            //注册依赖注入服务，将接口和实现类绑定
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            //开发者异常页面中间件用于开发环境下使用，快速定位错误信息，需注册在前
            if (env.IsDevelopment())
            {
                //对异常页进行配置
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                //设置报错代码行数
                developerExceptionPageOptions.SourceCodeLineCount = 25;
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }

/*
            //对默认文件中间件的默认文件做配置
            DefaultFilesOptions defaultFiles = new DefaultFilesOptions();
            defaultFiles.DefaultFileNames.Clear();
            defaultFiles.DefaultFileNames.Add("52abp.com.html");

            //添加默认文件中间件，可打开非wwwroot文件夹的文件，该中间件必须注册在UseStaticFiles中间件之前，否则无法生效
            app.UseDefaultFiles(defaultFiles);*/

            //添加静态文件中间件，用于打开wwwroot文件夹中的文件
            app.UseStaticFiles();

            /* //添加文件服务中间件，一般不推荐使用，该中间件会使项目文件目录暴露在公网之下
             app.UseFileServer();*/

            //使用默认路由
            //app.UseMvcWithDefaultRoute();

            //使用自定义路由,通过模板映射规则寻找URL
            app.UseMvc(routes => routes.MapRoute("default", "{controller}/{action}/{id?}"));

            /*更自由的路由方式，属性路由，只开启MVC服务，路由规则到控制器下配置,该方式可以完全自定义URL而不必按照{controller}/{action}/{id}
            模板定义路由规则，但其弊端是每个自定义的URL都需要到具体方法下配置，且被属性路由修饰过的方法会覆盖常规路由，可和常规自定义路由结合使用*/
            /* app.UseMvc();

             app.Run(async (context) =>
             {
                 await context.Response.WriteAsync("Hello World");
             });
 */
            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                    *//*var configureValue = _configuration["MyKey"];*//*
                    await context.Response.WriteAsync("第三个中间件 ");
                });
            });*/
        }
    }
}
