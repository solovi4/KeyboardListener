using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardListener
{
    [Serializable]
    public class ConfigUnitHolder
    {
        public ConfigUnit[] ConfigUnits;
        public ConfigUnitHolder()
        {

        }
        public ConfigUnitHolder(ConfigUnit[] configUnits)
        {
            ConfigUnits = configUnits;
        }
    }
}
