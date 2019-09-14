using System.IO;
using Newtonsoft.Json;

namespace DiscordTutorialBot
{
    public class Config
    {
        public struct BotConfig
        {
            public string Token;
            public string CommandPrefix;
        }

        private const string _configFolder = "Resourses";
        private const string _configFile = "config.json";

        public static BotConfig Bot;
        
        static Config()
        {
            if (!Directory.Exists(_configFolder))
                Directory.CreateDirectory(_configFolder);

            var fullPath = $"{_configFolder}/{_configFile}";
            
            if (File.Exists(fullPath))
            {
                var json = File.ReadAllText(fullPath);
                Bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
            else
            {
                Bot = new BotConfig();
                var json = JsonConvert.SerializeObject(Bot, Formatting.Indented);
                File.WriteAllText(fullPath, json);
            }
        }
    }
}