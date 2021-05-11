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
        private readonly IPokeAPIService pokeAPIService;

        public PokemonController(IPokeAPIService pokeAPIService)
        {
            this.pokeAPIService = pokeAPIService;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<PokemonDetails> Get(string name)
        {
            try
            {
                return await pokeAPIService.Get(name);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
