using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockSabbath.BuisnessLayer
{
    public class CommandResponse
    {
        public bool IsSuccess = false;
        public string? ErrorMessage = "Not sendnd";
        public string? Data;

        public static CommandResponse Error(string v)
        {
            CommandResponse response = new CommandResponse();
            response.ErrorMessage = v;
            
            return response;
        }
    }
}
