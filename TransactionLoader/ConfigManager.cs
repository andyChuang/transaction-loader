using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TransactionLoader
{
    class ConfigManager
    {
        private static ConfigManager instance = new ConfigManager();

        private ConfigManager() {}

        public static ConfigManager Instance
        {
            get
            {
                return instance;
            }
        }

        public static string ConfigPath
        {
            get;
            set;
        }

        public static JArray GetConfigs()
        {
            string data = FileReadService.Instance.ReadTextFileInOneString(ConfigPath);
            try
            {
                return JArray.Parse(@String.Join("", data));
            }
            catch
            {
                throw new Exception("Invalid config.");
            }
        }
    }
}
