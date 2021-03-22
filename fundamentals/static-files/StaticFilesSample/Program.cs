using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace StaticFilesSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();//访问Web 根目录中wwwroot 静态文件
                    //webBuilder.UseStartup<StartupRose>();//访问Web 根目录 wwwroot外静态文件
                    //webBuilder.UseStartup<StartupAddHeader>();//设置 HTTP 响应标头
                    //webBuilder.UseStartup<StartupBrowse>();//目录浏览
                    //webBuilder.UseStartup<StartupEmpty>();//提供默认文档
                    //webBuilder.UseStartup<StartupEmpty2>();
                    //webBuilder.UseStartup<StartupEmpty3>();//供静态文件、默认文件和目录浏览：
                    //webBuilder.UseStartup<StartupDefault>();//自定义默认文档
                    //webBuilder.UseStartup<StartupFileServer>(); //默认文档的 UseFileServer
                    //webBuilder.UseStartup<StartupFileExtensionContentTypeProvider>();//FileExtensionContentTypeProvider
                    //webBuilder.UseStartup<StartupServeUnknownFileTypes>();//非标准内容类型
                });
    }
}
