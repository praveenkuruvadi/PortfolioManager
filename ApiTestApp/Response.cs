using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestApp
{
    class Response
    {
        [JsonProperty("open")]
        public decimal open { get; set; }

        [JsonProperty("high")]
        public decimal high { get; set; }

        [JsonProperty("low")]
        public decimal low { get; set; }

        [JsonProperty("close")]
        public decimal close { get; set; }

        [JsonProperty("volume")]
        public int volume { get; set; }
    }
}
