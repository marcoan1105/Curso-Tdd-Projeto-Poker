using Curso_Tdd_Projeto_Poker.test;
using System;
using System.Linq;
using System.Text;
using Xunit;

namespace Curso_Tdd_Projeto_Poker.test
{
    public class AnalisadorDeVencedorComParDeCartasTest
    {
        private AnalisadorDeVencedorComParDeCartas _analisador;

        public AnalisadorDeVencedorComParDeCartasTest()
        {
            _analisador = new AnalisadorDeVencedorComParDeCartas();
        }
        [Theory]
        [InlineData("2O,2C,3P,6C,VC", "3O,5C,2E,9C,AE", "Primeiro Jogador")]
        [InlineData("3O,5C,2E,9C,AE", "2O,2C,3P,6C,VC", "Segundo Jogador")]
        [InlineData("DO,DC,2E,9C,AE", "2O,2C,3P,6C,VC", "Primeiro Jogador")]
        [InlineData("2O,2C,3P,6C,VC", "DO,DC,2E,9C,AE", "Segundo Jogador")]
        public void DeveAnalisarVencedorQuandoTiverUmaParDeCartasDoMesmoValor(string cartasDoPrimeiroJogadorString, string cartasDoSegundoJogadorString, string vencedorEsperado)
        {
            var cartasDoPrimeiroJogador = cartasDoPrimeiroJogadorString.Split(',').ToList();
            var cartasDoSegundoJogador = cartasDoSegundoJogadorString.Split(',').ToList();

            var vencedor = _analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

            Assert.Equal(vencedorEsperado, vencedor);
        }

        [Fact]
        public void NaoDeveAnalisarVencedorQuandoJogadorNaoTemParDeCartas()
        {
            var cartasDoPrimeiroJogador = "2O,4C,3P,6C,VC".Split(',').ToList();
            var cartasDoSegundoJogador = "3O,5C,2E,9C,AE".Split(',').ToList();

            var vencedor = _analisador.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

            Assert.Null(vencedor);
        }

        
    }
}
