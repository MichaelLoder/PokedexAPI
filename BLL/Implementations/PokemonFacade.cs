using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.PokeAPI;
using BLL.Translator;

namespace BLL.Implementations
{
    public class PokemonFacade : IPokemonFacade
    {
        private readonly IPokeAPIService _pokeApiService;
        private readonly IMapper _mapper;
        private readonly ITranslateService _translateService;

        public PokemonFacade(IPokeAPIService pokeApiService, IMapper mapper, ITranslateService translateService)
        {
            _pokeApiService = pokeApiService;
            _mapper = mapper;
            _translateService = translateService;
        }
        public async Task<PokedexDetails> GetPokemonDetails(string name)
        {
            return  _mapper.Map<PokedexDetails>(await _pokeApiService.Get(name));
        }

        public async Task<PokedexDetails> GetPokemonDetailsTranslated(string name)
        {
            var pokemonDetails = _mapper.Map<PokedexDetails>(await _pokeApiService.Get(name));
            var translated = await _translateService.TranslatePokemon(pokemonDetails);
            pokemonDetails.Description = translated.TranslatedContents.Text;
            return pokemonDetails;
        }
    }
}
