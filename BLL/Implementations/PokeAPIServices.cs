using BLL.Interfaces;
using BLL.Models;
using BLL.PokeAPI;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Implementations
{
    public class PokeAPIServices : IPokeAPIService
    {
        private readonly IOptions<APIEndpoints> apiEndpoints;
        private readonly IRestClient restClient;

        public PokeAPIServices(IOptions<APIEndpoints> apiEndpoints, IRestClient restClient)
        {
            this.apiEndpoints = apiEndpoints;
            this.restClient = restClient;
        }
        public async Task<PokemonDetails> Get(string name)
        {
            var data = await restClient.Get<PokemonDetails>(apiEndpoints.Value.PokemonSpecies.Replace("{NAME}", name));
            return data;
        }
    }
}
