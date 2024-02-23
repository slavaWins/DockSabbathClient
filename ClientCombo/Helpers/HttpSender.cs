using DockSabbath.BuisnessLayer;
using DockSabbath.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DockSabbath.Helpers
{
    public class HttpSender
    {
        public static CommandResponse CommandSendServer(ServerSetting serverSetting, string command)
        {

            CommandRequest request = new CommandRequest();
            request.data = command;


            request.hash = HashingHelper.Hash(command, serverSetting.token);


            string json = JsonConvert.SerializeObject(request);

            if (json == null)
            {
                return new CommandResponse()
                {
                    IsSuccess = false,
                    ErrorMessage = "The server gave an incorrect response",
                };
            }

            string response = SendPostRequest(json, serverSetting.server + "/api/rcon/command");

            if (response == null) return CommandResponse.Error("Server return empty response" );

            return JsonConvert.DeserializeObject<CommandResponse>(response);
        }

        public static string SendPostRequest(string jsonData, string url)
        {


            try
            {

                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";

                byte[] data = Encoding.UTF8.GetBytes(jsonData);

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {

                        if (responseStream == null)
                        {
                            return null;
                        }

                        using (StreamReader reader = new StreamReader(responseStream))
                        {

                            string responseText = reader.ReadToEnd();
                            return responseText;
                        }
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
