using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ErrorHandlingSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        #region snippet
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //开发人员异常页显示请求异常的详细信息
                //仅当应用程序在开发环境中运行时，前面的代码才启用开发人员异常页。 当应用在生产环境中运行时，不应公开显示详细的异常信息
                //开发人员异常页包括关于异常和请求的以下信息：堆栈跟踪；查询字符串参数（如果有）；Cookie（如果有）；标头。
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //若要为生产环境配置自定义错误处理页，请调用 UseExceptionHandler
                //捕获并记录异常。
                //使用指示的路径在备用管道中重新执行请求。 如果响应已启动，则不会重新执行请求。 模板生成的代码使用 / Error 路径重新执行请求。
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
        #endregion
    }
}
