using KeyboardListenerServicePrj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardListenerTestService
{
    class ServiceTester : KeyboardListenerService
    {
        public void StartTest(string[] args)
        {
            base.OnStart(args);
        }

        public void StopTest()
        {
            base.OnStop();
        }
    }
}
