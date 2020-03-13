using Curso_Tdd_Projeto_Poker.test;
using System;
using System.Linq;
using System.Text;
using Xunit;

namespace Curso_Tdd_Projeto_Poker.test
{
    public class AnalisadorDeVencedorComMaiorCartaTest
    {
        private AnalisadorDeVencedorComMaiorCarta _analisador;

        [Theory]
        [InlineData("2O,4C,3P,6C,7C", "3O,5C,2E,9C,7P", "Segundo Jogador")]
        [InlineData("3O,5C,2E,9C,7P", "2O,4C,3P,6C,7C", "Primeiro Jogador")]
        [InlineData("2O,4C,3P,6C,7C", "3O,5C,2E,9C,10E", "Segundo Jogador")]
        [InlineData("2O,4C,3P,6C,VC", "3O,5C,2E,9C,AE", "Segundo Jogador")]
        public void DeveAnalisarVencedorQuandoTiverMaiorCarta(string cartasDoPrimeiroJogadorString, string cartasDoSegundoJogadorString, string vencedorEsperado)
        {
            var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(',').ToList();
            var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(',').ToList();

            _analisador = new AnalisadorDeVencedorComMaiorCarta();

            var vencedor = _analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

            Assert.Equal(vencedorEsperado, vencedor);
        }

    }
}
