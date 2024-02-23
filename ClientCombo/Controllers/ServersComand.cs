using DockSabbath.BuisnessLayer;
using DockSabbath.Services.FastCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockSabbath.Controllers
{
    internal class ServersComand : CommandPackBack
    {

        public ServersComand()
        {


            rootCommand = "servers";
            destiption = "A list of your remote servers with DockSabbath";


            sectionInfo = "Servers";

        }



        public override void Exccute(List<string> arguments)
        {
            Console.WriteLine("Servers: ");

            foreach (var server in ConfigHelper.GetServers())
            {
                Console.WriteLine("  " + server.name + "  " + server.server);
            }
        }


    }
}
