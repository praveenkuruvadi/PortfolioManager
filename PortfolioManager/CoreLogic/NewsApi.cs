using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PortfolioManager.CoreLogic.ResponseJsons;
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
    public class NewsApi
    {
        public List<ResponseNewsJson> getTopNews()
        {
            List<ResponseNewsJson> response = new List<ResponseNewsJson>();
            HttpWebRequest request = (HttpWebRequest)WebRequest
    .Create(String.Format("https://newsapi.org/v1/articles?source=cnn&sortBy=top&apiKey={0}",Settings.Default.NewsApiKey));
            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            if (res.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = res.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                JArray data = (JArray)JObject.Parse(reader.ReadToEnd()).SelectToken("articles");
                response = JsonConvert.DeserializeObject<List<ResponseNewsJson>>(data.ToString());
            }
            return response;
        }
    }
}