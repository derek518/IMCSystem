using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace IMCSystem.Server
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ServiceRunner>();

                x.RunAsLocalSystem();

                x.SetDescription("智能药柜管理系统后台服务程序的描述");
                x.SetDisplayName("智能药柜管理系统后台服务程序");
                x.SetServiceName("IMCSystem2");

                x.UseNLog();
                x.OnException(ex =>
                {
                    // Do something with the exception
                    logger.Error(ex, "Catch exception");
                });

                x.EnableServiceRecovery(rc =>
                {
                    logger.Warn("Do the service recovery!");
                    rc.RestartService(1); // restart the service after 1 minute
                });
                x.StartAutomaticallyDelayed();
            });
        }
    }
}
