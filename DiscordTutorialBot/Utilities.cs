using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DiscordTutorialBot
{
    public class Utilities
    {
        public static Dictionary<string, string> Alerts { get; }

        static Utilities()
        {
            var json = File.ReadAllText("SystemLang/alerts.json");
            Alerts = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
        }
    }
}