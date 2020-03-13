using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Curso_Tdd_Projeto_Poker.test
{
    public class AnalisadorDeVencedor
    {
        private IAnalisadorDeVencedorComMaiorCarta _analisadorDeVencedorComMaiorCarta;
        private IAnalisadorDeVencedorComParDeCartas _analisadorDeVencedorComParDeCartas;

        public AnalisadorDeVencedor(IAnalisadorDeVencedorComMaiorCarta analisadorDeVencedorComMaiorCarta, IAnalisadorDeVencedorComParDeCartas analisadorDeVencedorComParDeCartas)
        {
            this._analisadorDeVencedorComMaiorCarta = analisadorDeVencedorComMaiorCarta;
            this._analisadorDeVencedorComParDeCartas = analisadorDeVencedorComParDeCartas;
        }

        public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
        {
            var vencedor = _analisadorDeVencedorComMaiorCarta.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

            if(vencedor == null)
                vencedor = _analisadorDeVencedorComParDeCartas.Analisar(cartasDoPrimeiroJogador, cartasDoSegundoJogador);

            return vencedor;

        }
    }
}
