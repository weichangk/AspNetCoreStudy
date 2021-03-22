using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ErrorHandlingSample
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
                    //webBuilder.UseStartup<Startup>();//开发人员异常页
                    //webBuilder.UseStartup<StartupLambda>();//异常处理程序页 - 异常处理程序 lambda
                    //webBuilder.UseStartup<StartupUseStatusCodePages>();//异常处理程序页 - 状态代码页中间件UseStatusCodePages
                    //webBuilder.UseStartup<StartupFormat>();//异常处理程序页 - 包含格式字符串的 UseStatusCodePages
                    //webBuilder.UseStartup<StartupStatusLambda>();//异常处理程序页 - 包含 lambda 的 UseStatusCodePages
                    webBuilder.UseStartup<StartupSCredirect>();//将客户端重定向到 URL 模板中提供的错误处理终结点 UseStatusCodePagesWithRedirects
                    //webBuilder.UseStartup<StartupSCreX>();//UseStatusCodePagesWithReExecute
                });
    }
}
