using DockSabbath.Controllers;
using DockSabbath.Services.FastCommand;

namespace DockSabbath
{
    internal class Program
    {
        static void Main(string[] args)
        {

            FastCommand.packs.Add(new ComboComand());
            FastCommand.packs.Add(new ServersComand());


            string command;
            string[] arguments;

            if (args.Length > 0)
            {
                command = args[0];

                arguments = new string[args.Length - 1];
                Array.Copy(args, 1, arguments, 0, args.Length - 1);

                ExecuteCommand(command, arguments);
            }
            else
            {
                FastCommand.Help();
                
            }
        }

        static void ExecuteCommand(string command, string[] arguments)
        {
            FastCommand.Run(command, arguments);
             
        }
    }
}