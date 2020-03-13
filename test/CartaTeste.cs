using System;
using ExpectedObjects;
using Xunit;

namespace Curso_Tdd_Projeto_Poker.test
{
    public class CartaTeste
    {
        [Theory]
        [InlineData("A", "O", 14)]
        [InlineData("10", "E", 10)]
        [InlineData("2", "P", 2)]
        public void DeveCriarUmaCarta(string valorDaCarta, string nipeDaCarta, int peso)
        {
            var cartaEsperada = new
            {
                Valor = valorDaCarta,
                Naipe = nipeDaCarta,
                Peso = peso
            };

            var carta = new Carta(cartaEsperada.Valor + cartaEsperada.Naipe);

            cartaEsperada.ToExpectedObject().ShouldMatch(carta);
        }

        [Theory]
        [InlineData("VE", 11)]
        [InlineData("DE", 12)]
        [InlineData("RE", 13)]
        [InlineData("AE", 14)]
        public void DeveCriarUmaCartaComPeso(string valorDaCarta, int pesoEsperado)
        {
            var carta = new Carta(valorDaCarta);

            Assert.Equal(pesoEsperado, carta.Peso);
        }

        [Theory]
        [InlineData("0O")]
        [InlineData("1O")]
        [InlineData("15O")]
        [InlineData("-1O")]

        public void DeveValidarValorDaCarta(string valorDaCartaInvalido)
        {
            var mensagem = (Assert.Throws<Exception>(() => new Carta(valorDaCartaInvalido))).Message;

            Assert.Equal("Valor da carta inválida", mensagem);
        }

        [Theory]
        [InlineData("10A")]
        [InlineData("10Z")]              
        public void DeveValidarNaipeDaCarta(string naipeCartaInvalido)
        {
            var mensagem = (Assert.Throws<Exception>(() => new Carta(naipeCartaInvalido))).Message;
            Assert.Equal("Naipe da carta inválida", mensagem);
        }

    }
}
