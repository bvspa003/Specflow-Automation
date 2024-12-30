using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkUtilities
{
    public class TestSettings
    {
        public string Browser {  get; set; }
        public string Url {  get; set; }
        public bool Headless { get; set; }
        public bool Incognito { get; set; }
        public bool AcceptInsecureCerts { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TypicodeEndpoint { get; set; }
        public string JokeEndpoint { get; set; }
        public string NASAEndpoint { get; set; }
        public string NASAKey { get; set; }

    }
    public class ConfigReader
    {
        public static TestSettings GetConfig(string path)
        {
            return JsonConvert.DeserializeObject<TestSettings>(File.ReadAllText(path));
        }
    }
}
