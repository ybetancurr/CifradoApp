using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CifradoApp.Helpers
{
    public static class InputValidator
    {
        public static bool EsNumeroValido(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return Regex.IsMatch(input, @"^\d{6}$");
        }

        public static string ObtenerMensajeError(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Debe ingresar un número.";
            }

            if (input.Length != 6)
            {
                return "El número debe tener exactamente 6 dígitos.";
            }

            if (!Regex.IsMatch(input, @"^\d+$"))
            {
                return "Solo se permiten caracteres numéricos.";
            }

            return string.Empty;
        }
    }
}
