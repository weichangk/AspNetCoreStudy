using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ErrorHandlingSample
{
    public class StartupSCredirect
    {
        public StartupSCredirect(IConfiguration configuration)
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

            //UseStatusCodePagesWithRedirects 扩展方法：将客户端重定向到 URL 模板中提供的错误处理终结点
            //向客户端发送“302 - 已找到”状态代码。
            //将客户端重定向到 URL 模板中提供的错误处理终结点。 错误处理终结点通常会显示错误信息并返回 HTTP 200。
            //URL 模板可能会包括状态代码的 {0} 占位符。 如果 URL 模板以波形符 ~（代字号）开头，则 ~ 会替换为应用的 PathBase。 在应用中指定终结点时，请为终结点创建 MVC 视图或 Razor 页面 Pages/MyStatusCode.cshtml。
            app.UseStatusCodePagesWithRedirects("/MyStatusCode?code={0}");
            //使用此方法通常是当应用：
            //应将客户端重定向到不同的终结点（通常在不同的应用处理错误的情况下）。 对于 Web 应用，客户端的浏览器地址栏反映重定向终结点。
            //不应保留原始状态代码并通过初始重定向响应返回该代码。

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
