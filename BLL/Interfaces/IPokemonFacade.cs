using BLL.PokeAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPokemonFacade
    {
        Task<PokedexDetails> GetPokemonDetails(string name);
        Task<PokedexDetails> GetPokemonDetailsTranslated(string name);
    }
}
