using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace removeAcentos
{
    public static class StringParser
    {
        /// <summary>
        /// Remove todos os sinais.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string removeSinais(string text, bool removeAcentos = false)
        {
            if (removeAcentos)
                text = StringParser.removeAcentos(text);

            return Regex.Replace(text, regexSinais, "").Trim();
        }

        /// <summary>
        /// Remove acentos de uma string especifica.
        /// </summary>
        /// <param name="text">Texto para ser removido os acentos.</param>
        /// <returns>Texto como os acentos removidos.</returns>
        public static string removeAcentos(string text)
        {
            for (int i = 0; i < regexAcentos.Length; i++)
            {
                text = Regex.Replace(text, regexAcentos[i], regexReplace[i]);
            }

            return text.Trim();
        }

        private static string regexSinais = "[-=_+.,;:/]";

        /// <summary>
        /// Acentos para o remove acentos.
        /// </summary>
        private static string[] regexAcentos = new List<string> {
            "[ÂÀÁÄÃ]", "[âãàáä]", "[ÊÈÉË]", "[êèéë]",
            "[ÎÍÌÏ]", "[îíìï]", "[ÔÕÒÓÖ]", "[ôõòóö]",
            "[ÛÙÚÜ]", "[ûúùü]", "[Ç]", "[ç]", "[“]",
            "[”]",
        }.ToArray();

        /// <summary>
        /// Valor de troca para os acentos.
        /// </summary>
        private static string[] regexReplace = new List<string> {
            "A", "a", "E", "e",
            "I", "i", "O", "o",
            "U", "u", "C", "c",
            "'", "'",
        }.ToArray();
    }
}
