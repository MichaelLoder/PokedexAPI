using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Implementations;
using BLL.Interfaces;
using BLL.Models;
using BLL.PokeAPI;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Pokedex.UnitTests.BLLTests
{
    public class PokeAPIServiceTests
    {
        private IPokeAPIService _sut;
        private Mock<IOptions<APIEndpoints>> _endpointMock;
        private Mock<IRestClient> _restClientMock;

        [SetUp]
        public void SetUp()
        {
            _endpointMock = new Mock<IOptions<APIEndpoints>>();
            _restClientMock = new Mock<IRestClient>();
            SetupAPIEndpoints();
            _sut = new PokeAPIServices(_endpointMock.Object, _restClientMock.Object);
        }

        [Test]
        public async Task When_valid_pokemon_name_return_details()
        {
            //ARRANGE
            _restClientMock.Setup(x => x.Get<PokemonDetails>(It.IsAny<string>())).ReturnsAsync(new PokemonDetails()
            {
                Name = "Test",
                IsLegendary = true
            });

            //ACT
            var result = await _sut.Get("test");

            //ASSERT
            result.Name.ShouldBe("Test");
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
