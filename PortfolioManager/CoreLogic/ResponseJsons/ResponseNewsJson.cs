using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortfolioManager.CoreLogic.ResponseJsons
{
    public class ResponseNewsJson
    {
        [JsonProperty("author")]
        public string author { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("url")]
        public Uri url { get; set; }

        [JsonProperty("urlToImage")]
        public Uri urlToImage { get; set; }

        [JsonProperty("publishedAt")]
        public string publishedAt { get; set; }
    }
}