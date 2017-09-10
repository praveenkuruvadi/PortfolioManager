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
        [JsonProperty("1.open")]
        public decimal open { get; set; }

        [JsonProperty("2.high")]
        public decimal high { get; set; }

        [JsonProperty("3.low")]
        public decimal low { get; set; }

        [JsonProperty("4.close")]
        public decimal close { get; set; }

        [JsonProperty("5.volume")]
        public int volume { get; set; }
    }
}
