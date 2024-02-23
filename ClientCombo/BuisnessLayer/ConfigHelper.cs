using DockSabbath.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DockSabbath.BuisnessLayer
{
    public class ConfigHelper
    {

        public static List<ServerSetting> GetServers()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            string content = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<ServerSetting>>(content);

        }
    }
}
