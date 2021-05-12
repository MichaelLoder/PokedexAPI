using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BLL.PokeAPI;

namespace BLL.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PokemonDetails, PokedexDetails>().ForMember(dst => dst.Description, mo
                    => mo.MapFrom(src => GetPokemonDescription(src.FlavorTextEntries)))
                .ForMember(src => src.IsLegendary,
                    mo => mo.MapFrom(dst => dst.IsLegendary))
                .ForMember(src => src.Name, mo =>
                    mo.MapFrom(dst => dst.Name))
                .ForMember(src => src.Habitat, mo => mo.MapFrom(dst => dst.Habitat.Name));

        }

        private string GetPokemonDescription(IEnumerable<FlavorTextEntry> descriptions)
        {
            return descriptions.FirstOrDefault(x => x.Language.Name == "en")?.Text ?? "";
        }

    }
}
