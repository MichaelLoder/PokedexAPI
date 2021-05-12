using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.PokeAPI;

namespace BLL.Translator
{
    public interface ITranslateService
    {
        Task<TranslationResponse> TranslatePokemon(PokedexDetails pokedexDetails);
    }
}
