using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Test_ELVA_WinForms.Model
{
    abstract class GeoPos
    {
        
        protected string connection;
        protected string Json;

        protected string GetJsonFromURL()
        {
            WebClient webClient = new WebClient { Encoding = Encoding.UTF8 };
            webClient.Headers["User-Agent"] = "Mozilla/5.0";
            return webClient.DownloadString(connection);        
        }

       

    }
}
