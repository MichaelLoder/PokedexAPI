using BLL.Interfaces;
using BLL.PokeAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonFacade _pokemonFacade;

        public PokemonController(IPokemonFacade pokemonFacade)
        {
            _pokemonFacade = pokemonFacade;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<PokedexDetails> Get(string name)
        {
            return await _pokemonFacade.GetPokemonDetails(name);
        }

        [HttpGet]
        [Route("translated/{name}")]
        public async Task<PokedexDetails> Translate(string name)
        {
            return await _pokemonFacade.GetPokemonDetailsTranslated(name);
        }
    }
}
