using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public static List<Dictionary<string, string>> GetConfigs()
        {  
            try
            {
                string data = FileReadService.Instance.ReadTextFileIntoOneString(ConfigPath);
                if (data == "")
                {
                    throw new Exception("Empty config file.");
                }
                List<Dictionary<string, string>> parsedData = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(data);
                return parsedData;
            }
            catch (Newtonsoft.Json.JsonSerializationException)
            {
                throw new Exception("Invalid config.");
            }
        }
    }
}
