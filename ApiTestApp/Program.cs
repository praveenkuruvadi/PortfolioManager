using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ApiTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest
                .Create(String.Format("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=MSFT&interval=1min&apikey=demo"));
            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            if (res.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = res.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                var data = JObject.Parse(reader.ReadToEnd()).Last.First.Children().ToList().First().Children();
                var dict = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(data.ToString());
                Response res1 = JsonConvert.DeserializeObject<Response>(data.ToString().Trim());
                //List<ResponseNewsJson> resClass = JsonConvert.DeserializeObject<List<ResponseNewsJson>>(data.ToString());
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
