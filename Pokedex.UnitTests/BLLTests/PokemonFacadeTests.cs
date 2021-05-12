using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Automapper;
using BLL.Implementations;
using BLL.Interfaces;
using BLL.PokeAPI;
using BLL.Translator;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Pokedex.UnitTests.BLLTests
{
    public class PokemonFacadeTests
    {
        private IPokemonFacade _sut;
        private Mock<IPokeAPIService> _pokeAPIServiceMock;
        private Mock<ITranslateService> _translateMock;
        private  MapperConfiguration _mapperConfig;

        [SetUp]
        public void Setup()
        {
            var mappingProfiles = new MappingProfile();
            _pokeAPIServiceMock = new Mock<IPokeAPIService>();
            _translateMock = new Mock<ITranslateService>();
            _mapperConfig = new MapperConfiguration(x => x.AddProfile(mappingProfiles));
            _sut = new PokemonFacade(_pokeAPIServiceMock.Object, _mapperConfig.CreateMapper(), _translateMock.Object);
        }

        [Test]
        public async Task When_given_a_valid_pokemon_return_mapped_object()
        {
            //ARRANGE
            
            _pokeAPIServiceMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(CreateDummyDetails("cave"));

            //ACT
            var result = await _sut.GetPokemonDetails("test");

            //ASSERT
            result.Description.ShouldBe("Test Content");
            result.Habitat.ShouldBe("cave");
            result.IsLegendary.ShouldBeFalse();
            result.Name.ShouldBe("Test Pokemon");
        }

        [Test]
        public async Task When_yoda_translation_translate_description()
        {
            //ARRANGE
            _pokeAPIServiceMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(CreateDummyDetails("cave"));
            _translateMock.Setup(x => x.TranslatePokemon(It.IsAny<PokedexDetails>())).ReturnsAsync(
                new TranslationResponse()
                {
                    TranslatedContents = new TranslatedContents()
                    {
                        Text = "YODA"
                    }
                });
            //ACT
            var result = await _sut.GetPokemonDetailsTranslated("test");

            //ASSERT
            result.Description.ShouldBe("YODA");
        }


        [Test]
        public async Task When_shakespeare_translation_translate_description()
        {
            //ARRANGE
            _pokeAPIServiceMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(CreateDummyDetails("hills"));
            _translateMock.Setup(x => x.TranslatePokemon(It.IsAny<PokedexDetails>())).ReturnsAsync(
                new TranslationResponse()
                {
                    TranslatedContents = new TranslatedContents()
                    {
                        Text = "SHAKE"
                    }
                });
            //ACT
            var result = await _sut.GetPokemonDetailsTranslated("test");

            //ASSERT
            result.Description.ShouldBe("SHAKE");
        }



        private PokemonDetails CreateDummyDetails(string habitat)
        {
            return new PokemonDetails()
            {
                Habitat = new Habitat()
                {
                    Name = habitat,
                },
                IsLegendary = false,
                FlavorTextEntries = new List<FlavorTextEntry>()
                {
                    new FlavorTextEntry()
                    {
                        Language = new Language()
                        {
                            Name = "en",
                            Url = "www.en.com"
                        },
                        Text = "Test Content"
                    }
                },
                Name = "Test Pokemon",
            };
        }
    }
}
