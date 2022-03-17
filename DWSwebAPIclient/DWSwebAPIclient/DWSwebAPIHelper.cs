using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DWSwebAPIclient
{
    internal class DWSwebAPIHelper
    {
        public void GetWebData(string MethodID) //Get the chosen method to call  
        {
            using (var client = new WebClient())   
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                //DWSwebAPI is setup to use localhost:5009
                var result = client.DownloadString("http://localhost:5009/DWSwebAPI/" + MethodID); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }
        }
    }
}
