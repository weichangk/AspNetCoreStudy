using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StaticFilesSample
{
    public class StartupServeUnknownFileTypes
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        #region snippet_Configure
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            #region snippet_UseStaticFiles
            //静态文件中间件可理解近 400 种已知文件内容类型。 如果用户请求文件类型未知的文件，则静态文件中间件将请求传递给管道中的下一个中间件。
            //如果没有中间件处理请求，则返回“404 未找到”响应。 如果启用了目录浏览，则在目录列表中会显示该文件的链接。
            //启用 ServeUnknownFileTypes 会形成安全隐患。 它默认处于禁用状态，不建议使用。 FileExtensionContentTypeProvider 提供了更安全的替代方法来提供含非标准扩展名的文件。

            //以下代码提供未知类型，并以图像形式呈现未知文件：
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "image/png"
            });
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
        #endregion
    }
}
