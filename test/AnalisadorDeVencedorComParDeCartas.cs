using System.Collections.Generic;
using System.Linq;

namespace Curso_Tdd_Projeto_Poker.test
{
    public class AnalisadorDeVencedorComParDeCartas : IAnalisadorDeVencedorComParDeCartas
    {
        public string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador)
        {
            var parDeCartasDoPrimeiroJogador = cartasDoPrimeiroJogador.Select(carta => new Carta(carta).Peso).GroupBy(peso => peso).Where(grupo => grupo.Count() > 1);
            var parDeCartasDoSegundoJogador = cartasDoSegundoJogador.Select(carta => new Carta(carta).Peso).GroupBy(peso => peso).Where(grupo => grupo.Count() > 1);

            if (parDeCartasDoPrimeiroJogador != null && parDeCartasDoPrimeiroJogador.Any() && parDeCartasDoSegundoJogador != null && parDeCartasDoSegundoJogador.Any())
            {
                var maiorParDeCartasDoPrimeiroJogador = parDeCartasDoPrimeiroJogador.Select(valor => valor.Key).OrderBy(valor => valor).Max();
                var maiorParDeCartasDoSegundoJogador = parDeCartasDoSegundoJogador.Select(valor => valor.Key).OrderBy(valor => valor).Max();

                if (maiorParDeCartasDoPrimeiroJogador > maiorParDeCartasDoSegundoJogador)
                {
                    return "Primeiro Jogador";
                }
                else if (maiorParDeCartasDoPrimeiroJogador < maiorParDeCartasDoSegundoJogador)
                {
                    return "Segundo Jogador";
                }
            }

            if (parDeCartasDoPrimeiroJogador != null && parDeCartasDoPrimeiroJogador.Any())
            {
                return "Primeiro Jogador";
            }

            if (parDeCartasDoSegundoJogador != null && parDeCartasDoSegundoJogador.Any())
            {
                return "Segundo Jogador";
            }

            return null;
        }
    }
}
