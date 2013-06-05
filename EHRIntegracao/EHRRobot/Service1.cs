using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EHRRobot
{
    public partial class Service1 : ServiceBase
    {
        private static EventLog eventLog1 = new EventLog();

        public Service1()
        {
            InitializeComponent();

            //System.Diagnostics.EventLog.DeleteEventSource("MyNewLog");

            if (!System.Diagnostics.EventLog.SourceExists("Workker"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "Workker", "WorkkerLog");
            }

            eventLog1.Source = "Workker";
            eventLog1.Log = "WorkkerLog";
        }

        private static void timer1_Elapsed(object sender, EventArgs e)
        {
            eventLog1.WriteEntry("Integrei");
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");

            Timer timer1 = new Timer();

            timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer1.Interval = 420000;
            timer1.Enabled = true;
            timer1.Start();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }

        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }

    }
}
