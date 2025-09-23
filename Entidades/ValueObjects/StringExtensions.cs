using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ValueObjects
{
    /// <summary>
    /// Extensiones para la clase string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Capitaliza la primera letra de un texto
        /// </summary>
        public static string Capitalize(this string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;
            return char.ToUpper(texto[0]) + texto.Substring(1);
        }


        /// <summary>
        /// Capitaliza la primera letra de cada palabra en un texto
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CapitalizeWords(this string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return string.Join(" ", text.Split(' ')
                                        .Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));
        }
    }
}
