using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PortfolioManager.CoreLogic.Interfaces;
using PortfolioManager.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PortfolioManager.CoreLogic
{
    public class AlphaVantageApi : IApiQueryBuilder
    {

        public Dictionary<DateTime, decimal> GetSMA(string Symbol, int Interval, int Period)
        {
            throw new NotImplementedException();
        }

        public Tuple<string, decimal> GetSymbolQuote(string Symbol)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest
                .Create(String.Format("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={0}&interval=1min&apikey={1}",Symbol,Settings.Default.APIKEY));
            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            if (res.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = res.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                JArray data = (JArray)JObject.Parse(reader.ReadToEnd()).SelectToken("articles");
               // List<ResponseNewsJson> resClass = JsonConvert.DeserializeObject<List<ResponseNewsJson>>(data.ToString());
                Console.WriteLine(reader.ReadToEnd());
            }
            return null;
        }

        public Dictionary<DateTime, decimal> GetWMA(string Symbol, int Interval, int Period)
        {
            throw new NotImplementedException();
        }
    }
}