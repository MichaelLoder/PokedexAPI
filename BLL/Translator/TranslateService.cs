using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using BLL.PokeAPI;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BLL.Translator
{
    public class TranslateService : ITranslateService
    {
        private readonly IRestClient _restClient;
        private readonly IOptions<APIEndpoints> _apiEndpoints;

        public TranslateService(IRestClient restClient, IOptions<APIEndpoints> apiEndpoints)
        {
            _restClient = restClient;
            _apiEndpoints = apiEndpoints;
        }
        public async Task<TranslationResponse> TranslatePokemon(PokedexDetails pokedexDetails)
        {
            try
            {
                if (pokedexDetails.IsLegendary || pokedexDetails.Habitat.ToLower() == "cave")
                {
                    return await _restClient.Post<TranslationResponse>(_apiEndpoints.Value.YodaTranslator,
                        $"text={pokedexDetails.Description}");
                }
                return await _restClient.Post<TranslationResponse>(_apiEndpoints.Value.ShakespeareTranslator,
                    $"text={pokedexDetails.Description}");
            }
            catch (Exception e)
            {
                return new TranslationResponse()
                {
                    TranslatedContents = new TranslatedContents()
                    {
                        Text = pokedexDetails.Description
                    }
                };
            }
          
        }
    }
}
