using DockSabbath.BuisnessLayer;
using DockSabbath.Contracts;
using DockSabbath.Helpers;
using DockSabbath.Services.FastCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockSabbath.Controllers
{
    internal class ComboComand : CommandPackBack
    {

        public ComboComand()
        {

            rootCommand = "docksab";
            destiption = "Execute the command on the machine in the DockSabbath application";
            sectionInfo = "Main";

            arguments.Add("serverId"); 

            ghostHelps.Add("[serverId] ns List namespaces");
            ghostHelps.Add("[serverId] pods [ns] List pods");
            ghostHelps.Add("[serverId] up [ns] Start");
            ghostHelps.Add("[serverId] stop [ns] Stop");
            ghostHelps.Add("[serverId] sdbu [ns] Update from git");


        }

        public override void Exccute(List<string> arguments)
        {


            ServerSetting? server = ConfigHelper.GetServers().Find(e => e.name == arguments[0]);

            if (server == null)
            {
                Console.WriteLine("Server not found: " + arguments[0]);
                return;
            }

            string cmd = "";
            for (int i = 1; i < arguments.Count; i++)
            {
                cmd += " " + arguments[i];
            }
            cmd = cmd.Trim();

            var response = HttpSender.CommandSendServer(server, cmd);
            if (!response.IsSuccess)
            {
                Console.WriteLine(response.ErrorMessage);
                return;
            }
            Console.WriteLine(response.Data);
        }



    }
}
