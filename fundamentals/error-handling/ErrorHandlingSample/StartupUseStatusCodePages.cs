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
    public class StartupUseStatusCodePages
    {
        public StartupUseStatusCodePages(IConfiguration configuration)
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
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            //默认情况下，ASP.NET Core 应用不会为 HTTP 错误状态代码（如“404 - 未找到”）提供状态代码页。 当应用遇到没有正文的 HTTP 400-599 错误状态代码时，它将返回状态代码和空响应正文。
            //若要提供状态代码页，请使用状态代码页中间件。 若要启用常见错误状态代码的默认纯文本处理程序，请在 Startup.Configure 方法中调用 UseStatusCodePages：

            //在请求处理中间件之前调用 UseStatusCodePages。 例如，在静态文件中间件和端点中间件之前调用 UseStatusCodePages。
            //未使用 UseStatusCodePages 时，导航到没有终结点的 URL 会返回一条与浏览器相关的错误消息，指示找不到终结点。

            //UseStatusCodePages 通常不在生产中使用，因为它返回对用户没有用的消息。
            app.UseStatusCodePages();//状态代码页中间件UseStatusCodePages

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
