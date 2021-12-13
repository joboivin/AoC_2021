using System.Text.RegularExpressions;

namespace AoC2021.Day12;

internal static class StringExtensions
{
    public static bool IsUpperCase(this string value)
    {
        var upperCasePattern = "^[A-Z]*$";
        var upperCaseRegex = new Regex(upperCasePattern);

        return upperCaseRegex.IsMatch(value);
    }
}
