using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace IMCSystem.Server
{
    public partial class IMCService : ServiceBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IMCService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            logger.Trace("Enter...");

            App.Instance.Start();

            logger.Trace("Leave...");
        }

        protected override void OnStop()
        {
            logger.Trace("Enter...");

            App.Instance.Stop();

            logger.Trace("Leave...");
        }
    }
}
