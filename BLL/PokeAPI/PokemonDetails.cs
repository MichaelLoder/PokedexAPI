using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.PokeAPI
{
    public class PokemonDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("order")]
        public int Order { get; set; }
        [JsonProperty("is_legendary")]
        public bool Islegendary { get; set; }
        [JsonProperty("is_mythical")]
        public bool Ismythical { get; set; }
        [JsonProperty("habitat")]
        public Habitat Habitat { get; set; }
        [JsonProperty("Names")]
        public List<PokemonName> Names { get; set; }
        [JsonProperty("form_descriptions")]
        public List<FormDescription> FormDescriptions { get; set; }

    }
}
