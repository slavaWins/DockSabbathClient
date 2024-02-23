using DockSabbath.BuisnessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockSabbath.Services.FastCommand
{



    internal class FastCommand
    {
        public static List<CommandPackBack> packs = new List<CommandPackBack>();

        public static void Help()

        {


            foreach (var pack in packs)
            {

                Console.WriteLine("\n" + pack.sectionInfo + " Commands:");



                int margin = 25;

                string txt = "  " + pack.rootCommand;

                foreach (string arg in pack.arguments)
                {
                    txt += " [" + arg + "]";
                }

                for (int i = txt.Length; i < margin; i++)
                {
                    txt += " ";
                }

                txt += pack.destiption;



                Console.WriteLine(txt);

                foreach (string ghost in pack.ghostHelps)
                {
                    Console.WriteLine("  " + pack.rootCommand + " " + ghost);
                }
            }
        }

        public static void Run(string command, string[] arguments)
        {
            foreach (var pack in packs)
            {

                bool isThisPack = false;

                if (pack.rootCommand == command) isThisPack=true;

                if (!isThisPack)
                {
                    foreach (var server in ConfigHelper.GetServers())
                    {
                        if (server.name == command && pack.rootCommand == "docksab")
                        {
                            
                            isThisPack = true;
                            break;
                        }
                    }
                }

                if (!isThisPack) continue;

 

                if (arguments.Length < pack.arguments.Count) continue;

                 

                List<string> strings = new List<string>();
                for (int i = 0; i < arguments.Length; i++)
                {
                    strings.Add(arguments[i]);
                }

                if(pack.rootCommand == "docksab")
                {
                    strings.Insert(0, command);
                }
                pack.call(strings);

                return;

            }

            Help();

        }
    }
}