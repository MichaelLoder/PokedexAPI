using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.PokeAPI
{
    public class FormDescription
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("language")]
        public Language Language { get; set; }
    }
}
