using System.Collections.Generic;
using System.Linq;

namespace Curso_Tdd_Projeto_Poker.test
{
    public class AnalisadorDeVencedorComMaiorCarta : IAnalisadorDeVencedorComMaiorCarta
    {

        public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
        {
            var cartaComMaiorPesoDoPrimeiroJogador = cartasDoPrimeiroJogador.Select(carta => new Carta(carta).Peso).OrderBy(carta => carta).Max();
            var cartaComMaiorPesoDoSegundoJogador = cartasDoSegundoJogador.Select(carta => new Carta(carta).Peso).OrderBy(carta => carta).Max();

            return cartaComMaiorPesoDoPrimeiroJogador > cartaComMaiorPesoDoSegundoJogador ? "Primeiro Jogador" : "Segundo Jogador";
        }
    }
}
