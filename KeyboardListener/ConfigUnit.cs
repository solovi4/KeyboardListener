using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardListener
{
    [Serializable]
    public class ConfigUnit
    {
        public string DeviceID;
        public string Key;
        public string Action;
        public ConfigUnit()
        {

        }

        public ConfigUnit(string DeviceID, string Key, string Action)
        {
            this.DeviceID = DeviceID;
            this.Key = Key;
            this.Action = Action;
        }
    }
}
