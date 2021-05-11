using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.PokeAPI
{
    public class Language
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
