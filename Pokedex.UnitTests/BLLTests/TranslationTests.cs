using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using BLL.PokeAPI;
using BLL.Translator;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Pokedex.UnitTests.BLLTests
{

    public class TranslationTests
    {
        private ITranslateService _sut;
        private Mock<IOptions<APIEndpoints>> _endpointMock;
        private Mock<IRestClient> _restClientMock;

        [SetUp]
        public void Setup()
        {
            _endpointMock = new Mock<IOptions<APIEndpoints>>();
            _restClientMock = new Mock<IRestClient>();
            SetupAPIEndpoints();
            _sut = new TranslateService(_restClientMock.Object, _endpointMock.Object);
        }

        [Test]
        public async Task When_translation_fails_return_default_description()
        {
            //ARRANGE
            _restClientMock.Setup(x => x.Post<TranslationResponse>(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception());
            //ACT
            var result = await _sut.TranslatePokemon(new PokedexDetails()
            {
                Description = "TEST"
            });
            
            //ASSERT
            result.TranslatedContents.Text.ShouldBe("TEST");
        }

        private void SetupAPIEndpoints()
        {
            _endpointMock.Setup(x => x.Value).Returns(new APIEndpoints()
            {
                YodaTranslator = "www.yodatest.com",
                ShakespeareTranslator = "www.shakespeare.com",
                PokemonSpecies = "www.pokemon.com"
            });
        }
    }
}
