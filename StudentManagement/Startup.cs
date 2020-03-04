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
            //ע��MVC
            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();

            //ע������ע����񣬽��ӿں�ʵ�����
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            //�������쳣ҳ���м�����ڿ���������ʹ�ã����ٶ�λ������Ϣ����ע����ǰ
            if (env.IsDevelopment())
            {
                //���쳣ҳ��������
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                //���ñ����������
                developerExceptionPageOptions.SourceCodeLineCount = 25;
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }

/*
            //��Ĭ���ļ��м����Ĭ���ļ�������
            DefaultFilesOptions defaultFiles = new DefaultFilesOptions();
            defaultFiles.DefaultFileNames.Clear();
            defaultFiles.DefaultFileNames.Add("52abp.com.html");

            //���Ĭ���ļ��м�����ɴ򿪷�wwwroot�ļ��е��ļ������м������ע����UseStaticFiles�м��֮ǰ�������޷���Ч
            app.UseDefaultFiles(defaultFiles);*/

            //��Ӿ�̬�ļ��м�������ڴ�wwwroot�ļ����е��ļ�
            app.UseStaticFiles();

            /* //����ļ������м����һ�㲻�Ƽ�ʹ�ã����м����ʹ��Ŀ�ļ�Ŀ¼��¶�ڹ���֮��
             app.UseFileServer();*/

            //ʹ��Ĭ��·��
            //app.UseMvcWithDefaultRoute();

            //ʹ���Զ���·��,ͨ��ģ��ӳ�����Ѱ��URL
            app.UseMvc(routes => routes.MapRoute("default", "{controller}/{action}/{id?}"));

            /*�����ɵ�·�ɷ�ʽ������·�ɣ�ֻ����MVC����·�ɹ��򵽿�����������,�÷�ʽ������ȫ�Զ���URL�����ذ���{controller}/{action}/{id}
            ģ�嶨��·�ɹ��򣬵���׶���ÿ���Զ����URL����Ҫ�����巽�������ã��ұ�����·�����ι��ķ����Ḳ�ǳ���·�ɣ��ɺͳ����Զ���·�ɽ��ʹ��*/
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
                    await context.Response.WriteAsync("�������м�� ");
                });
            });*/
        }
    }
}
