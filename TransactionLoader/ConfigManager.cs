using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransactionLoaderBase;

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
        /// <summary>
        /// Get config with json format
        /// </summary>
        /// <returns></returns>
        public static List<Dictionary<string, string>> GetConfigs()
        {  
            try
            {
                string data = FileReadService.Instance.ReadTextFileIntoOneString(ConfigPath);
                List<Dictionary<string, string>> parsedData = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(data);
                return parsedData;
            }
            catch (Newtonsoft.Json.JsonSerializationException)
            {
                throw new CustomException("Invalid config.");
            }
        }
    }
}
