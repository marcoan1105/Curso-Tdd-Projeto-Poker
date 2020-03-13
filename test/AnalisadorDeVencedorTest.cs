using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Curso_Tdd_Projeto_Poker.test
{
    public class AnalisadorDeVencedorTest
    {
        public AnalisadorDeVencedor _analisadorDeVencedor { get; private set; }

        private List<string> _cartasDoPrimeiroJogador;
        private List<string> _cartasDoSegundoJogador;
        private Mock<IAnalisadorDeVencedorComMaiorCarta> _analisadorDeVencedorComParDeCartas;
        private Mock<IAnalisadorDeVencedorComParDeCartas> _analisadorDeVencedorComMaiorCarta;

        public AnalisadorDeVencedorTest()
        {
            _analisadorDeVencedorComParDeCartas = new Mock<IAnalisadorDeVencedorComMaiorCarta>();
            _analisadorDeVencedorComMaiorCarta = new Mock<IAnalisadorDeVencedorComParDeCartas>();

            _analisadorDeVencedor = new AnalisadorDeVencedor(_analisadorDeVencedorComParDeCartas.Object, _analisadorDeVencedorComMaiorCarta.Object);

            _cartasDoPrimeiroJogador = "2O,4C,3P,6C,VC".Split(',').ToList();
            _cartasDoSegundoJogador = "3O,5C,2E,9C,AE".Split(',').ToList();
        }


        [Fact]
        public void DeveAnalisarVencedorQueTemMaiorCarta()
        {           
            _analisadorDeVencedorComMaiorCarta.Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador)).Returns("Segundo Jogador");

            _analisadorDeVencedor.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

            _analisadorDeVencedorComMaiorCarta.Verify(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador));
        }

        [Fact]
        public void DeveAnalisarVencedorQueTemParDeCartas()
        {
            _analisadorDeVencedorComParDeCartas.Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador)).Returns("Segundo Jogador");            

            _analisadorDeVencedor.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

            _analisadorDeVencedorComParDeCartas.Verify(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador));
        }

        [Fact]
        public void NaoDevAnalisarVencedorComMaiorCartaQuandoJogadorTerCartasComPar()
        {
            _analisadorDeVencedorComParDeCartas.Setup(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador)).Returns("Segundo Jogador");

            _analisadorDeVencedor.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador);

            _analisadorDeVencedorComMaiorCarta.Verify(analisador => analisador.Analisar(_cartasDoPrimeiroJogador, _cartasDoSegundoJogador), Times.Never);
        }


    }
}
