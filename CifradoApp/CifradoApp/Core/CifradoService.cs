using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoApp.Core
{
    public static class CifradoService
    {
        public static string CifrarNumero(string input)
        {
            int[] digitos = ConvertirADigitos(input);

            digitos = AplicarSuma(digitos);
            digitos = IntercambiarPosiciones(digitos);

            return DigitosACadena(digitos);
        }

        public static string DescifrarNumero(string input)
        {
            int[] digitos = ConvertirADigitos(input);

            digitos = RevertirIntercambio(digitos);
            digitos = AplicarResta(digitos);

            return DigitosACadena(digitos);
        }

        private static int[] ConvertirADigitos(string input)
        {
            int[] digitos = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                digitos[i] = input[i] - '0';
            }

            return digitos;
        }

        private static int[] AplicarSuma(int[] digitos)
        {
            int[] resultado = new int[digitos.Length];

            for (int i = 0; i < digitos.Length; i++)
            {
                resultado[i] = (digitos[i] + 7) % 10;
            }

            return resultado;
        }

        private static int[] AplicarResta(int[] digitos)
        {
            int[] resultado = new int[digitos.Length];

            for (int i = 0; i < digitos.Length; i++)
            {
                resultado[i] = (digitos[i] - 7 + 10) % 10;
            }

            return resultado;
        }

        private static int[] IntercambiarPosiciones(int[] digitos)
        {
            int[] resultado = (int[])digitos.Clone();

            Intercambiar(resultado, 0, 2);
            Intercambiar(resultado, 1, 3);
            Intercambiar(resultado, 4, 5);

            return resultado;
        }

        private static int[] RevertirIntercambio(int[] digitos)
        {
            int[] resultado = (int[])digitos.Clone();

            Intercambiar(resultado, 4, 5);
            Intercambiar(resultado, 1, 3);
            Intercambiar(resultado, 0, 2);

            return resultado;
        }

        private static void Intercambiar(int[] arreglo, int i, int j)
        {
            int temporal = arreglo[i];
            arreglo[i] = arreglo[j];
            arreglo[j] = temporal;
        }

        private static string DigitosACadena(int[] digitos)
        {
            return string.Concat(digitos);
        }
    }
}
