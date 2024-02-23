namespace DockSabbath.Services.FastCommand
{
    public class CommandPackBack
    {

        public string rootCommand;
        public string sectionInfo = "Main";
        public string destiption;
        public Action<List<string>> call;

        public CommandPackBack()
        {
            call = Exccute;
        }

        public List<string> arguments = new List<string>();

        public List<string> ghostHelps = new List<string>();


        public virtual void Exccute(List<string> arguments)
        {
            Console.WriteLine("Not found");
        }
    }
}