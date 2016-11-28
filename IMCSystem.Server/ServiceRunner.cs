using IMCSystem.Server.Models;
using Microsoft.Owin.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace IMCSystem.Server
{
    class ServiceRunner : ServiceControl
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        //private Timer _timer = null;
        //private readonly IScheduler scheduler;
        private IDisposable webApp;

        public ServiceRunner()
        {
            //scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //_timer = new Timer(1000) { AutoReset = true };
            //_timer.Elapsed += (sender, eventArgs) => logger.Info(DateTime.Now);
        }

        public bool Start(HostControl hostControl)
        {
            logger.Trace("Enter...");

            //_timer.Start();

            try
            {
                //scheduler.Start();

                string baseAddress = "http://localhost:9999/";
                webApp = WebApp.Start<Startup>(url: baseAddress);

                using (var ctx = new IMCContext())
                {
                    ctx.Database.CreateIfNotExists();

                    User user = new User()
                    {
                        Name = "达克宁",
                    };

                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }

            }
            catch (Exception e)
            {
                logger.Error("Exception happened!" + e.ToString());
            }

            logger.Trace("Leave...");

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            logger.Trace("Enter...");

            //_timer.Stop();

            if (webApp != null) webApp.Dispose();
            //scheduler.Shutdown(false);

            logger.Trace("Leave...");
            
            return true;
        }
    }
}
