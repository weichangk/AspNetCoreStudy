using Microsoft.Extensions.Logging;

#region snippet_LoggerFactory
class Program
{
    //非托管控制台应用
    static void Main(string[] args)
    {
        //在非主机控制台应用中，在创建 LoggerFactory 时调用提供程序的 Add{provider name} 扩展方法
        //若要创建日志，请使用 ILogger<TCategoryName> 对象。 使用 LoggerFactory 创建一个 ILogger。
        //记录器用于创建级别为 Information 的日志
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                .AddConsole()
                .AddEventLog();
        });
        ILogger logger = loggerFactory.CreateLogger<Program>();
        logger.LogInformation("Example log message");
    }
}
#endregion