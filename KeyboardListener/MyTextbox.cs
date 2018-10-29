using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KeyboardListener
{
    class MyTextbox : TextBox
    {
        public string DeviceID { get; private set; }
        public string Key { get; private set; }

        public void SetDeviceAndKey(string device, string key)
        {
            DeviceID = device;
            Key = key;
            Text = $"Device={device} Key={key}";
        }
        
    }
}
