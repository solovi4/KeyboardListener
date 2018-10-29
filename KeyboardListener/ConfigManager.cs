using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KeyboardListener
{
    static class ConfigManager
    {
        private const string fileName = "config.xml";
        public static void Save(ConfigUnit[] configUnits)
        {
            ConfigUnitHolder configUnitHolder = new ConfigUnitHolder(configUnits);
            FileStream fileStream = File.Create(fileName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConfigUnitHolder));
            xmlSerializer.Serialize(fileStream, configUnitHolder);
            fileStream.Close();
            
        }
        public static ConfigUnit[] Load()
        {
            FileStream fileStream = File.OpenRead(fileName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConfigUnitHolder));
            ConfigUnitHolder configUnitHolder = (ConfigUnitHolder)xmlSerializer.Deserialize(fileStream);
            return configUnitHolder.ConfigUnits;
        }
    }
}
