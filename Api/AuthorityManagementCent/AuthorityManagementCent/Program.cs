using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace AuthorityManagementCent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NLog.Web.NLogBuilder.ConfigureNLog("nlog.config");
            ////约定访问地址
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls($"http://*:{5002}")
                .Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders(); //移除已经注册的其他日志处理程序
                        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); //设置最小的日志级别
                    })
                    .UseNLog();
    }
}
