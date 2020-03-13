using System;

namespace Curso_Tdd_Projeto_Poker.test
{
    public class Carta
    {
        public string Valor { get; private set; }

        public int Peso { get; private set; }
        public string Naipe { get; private set; }

        public Carta(string carta)
        {
            Valor = carta.Substring(0, carta.Length - 1);
            Naipe = carta.Replace(Valor, string.Empty);

            if (Naipe != "O" && Naipe != "C" && Naipe != "E" && Naipe != "P")
                throw new Exception("Naipe da carta inválida");
            
            ConverterParaPesoDaCarta(Valor);

            if (Peso < 2 || Peso > 14)
                throw new Exception("Valor da carta inválida");
        }

        private void ConverterParaPesoDaCarta(string valorDaCarta)
        {
            int valor = 0;

            if (!int.TryParse(valorDaCarta, out valor))
            {
                switch (valorDaCarta)
                {
                    case "V":
                        valor = 11;
                        break;
                    case "D":
                        valor = 12;
                        break;
                    case "R":
                        valor = 13;
                        break;
                    case "A":
                        valor = 14;
                        break;
                }
            }

            Peso = valor;
        }
    }
}
