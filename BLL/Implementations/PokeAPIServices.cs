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
        private readonly IOptions<APIEndpoints> _apiEndpoints;
        private readonly IRestClient _restClient;

        public PokeAPIServices(IOptions<APIEndpoints> apiEndpoints, IRestClient restClient)
        {
            this._apiEndpoints = apiEndpoints;
            this._restClient = restClient;
        }
        public async Task<PokemonDetails> Get(string name)
        {
            var data = await _restClient.Get<PokemonDetails>(_apiEndpoints.Value.PokemonSpecies.Replace("{NAME}", name));
            return data;
        }
    }
}
