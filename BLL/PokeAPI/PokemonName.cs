using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.PokeAPI
{
    public class PokemonName
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("language")]
        public Language Language { get; set; }
    }
}
