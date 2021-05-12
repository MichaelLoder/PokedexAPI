using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BLL.PokeAPI
{
    public class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string Text { get; set; }
        [JsonProperty("language")]
        public Language Language { get; set; }
    }
}
