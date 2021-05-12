using BLL.PokeAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPokeAPIService
    {
        Task<PokemonDetails> Get(string name);
    }
}
