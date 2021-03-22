using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ErrorHandlingSample
{
    public class StartupSCreX
    {
        public StartupSCreX(IConfiguration configuration)
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
            //UseStatusCodePagesWithReExecute 扩展方法：
            //向客户端返回原始状态代码。
            //通过使用备用路径重新执行请求管道，从而生成响应正文。
            //如果在应用中指定终结点，请为终结点创建 MVC 视图或 Razor 页面。 确保将 UseStatusCodePagesWithReExecute 放置在 UseRouting 之前，以便可以将请求重新路由到状态页
            app.UseStatusCodePagesWithReExecute("/MyStatusCode2", "?code={0}");
            //使用此方法通常是当应用应：
            //处理请求，但不重定向到不同终结点。 对于 Web 应用，客户端的浏览器地址栏反映最初请求的终结点。
            //保留原始状态代码并通过响应返回该代码。

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
