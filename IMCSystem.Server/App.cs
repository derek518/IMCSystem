using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using NLog;
using Microsoft.Owin.Hosting;
using IMCSystem.Server.Models;
using System.IO;
using System.Data.Entity;

namespace IMCSystem.Server
{
    public class App
    {
        private static readonly App instance = new App();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IDisposable webApp;

        private App() { }

        public static App Instance
        {
            get { return instance; }
        }

        public void Start()
        {
            logger.Trace("Enter...");

            try
            {
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
        }

        public void Stop()
        {
            logger.Trace("Enter...");

            if (webApp != null) webApp.Dispose();

            logger.Trace("Leave...");
        }
    }
}
