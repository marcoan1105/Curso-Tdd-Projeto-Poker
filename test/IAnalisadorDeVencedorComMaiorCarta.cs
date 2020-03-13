using System;
using System.Collections.Generic;
using System.Text;

namespace Curso_Tdd_Projeto_Poker.test
{
    public interface IAnalisadorDeVencedorComMaiorCarta
    {
        string Analisar(List<string> cartasDoPrimeiroJogador, List<string> cartasDoSegundoJogador);
    }
}
