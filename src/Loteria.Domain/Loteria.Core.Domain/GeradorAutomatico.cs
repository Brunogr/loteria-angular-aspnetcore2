using System;
using System.Linq;

namespace Loteria.Core.Domain
{
    public static class GeradorAutomatico
    {
        private static readonly Random _random = new Random();
        public static int[] Cartela(int minimo, int maximo, int quantidadeDeNumeros)
        {
            int[] numeros = new int[quantidadeDeNumeros];

            for (int i = 0; i < quantidadeDeNumeros; i++)
            {
                numeros[i] = _random.Next(minimo, maximo);
                //Garantindo que não gera números repetidos.
                while (numeros.Where(n => n == numeros[i]).Count() > 1)
                {
                    numeros[i] = _random.Next(minimo, maximo);
                }
            }

            return numeros;
        }
    }
}
