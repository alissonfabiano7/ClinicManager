using System.Globalization;
using System.Text;

namespace ClinicManager.Application.Common.Helpers
{
    public static class TextNormalizer
    {
        /// <summary>
        /// Removes accents and converts the string to uppercase.
        /// </summary>
        public static string Normalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            string decomposed = input.Normalize(NormalizationForm.FormD);
            var filtered = decomposed
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new string(filtered).ToUpperInvariant();
        }
    }
}