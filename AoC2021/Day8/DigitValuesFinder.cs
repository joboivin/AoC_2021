namespace AoC2021.Day8;

internal class DigitValuesFinder : IDigitValuesFinder
{
    public IList<Digit> FindDigitValues(string input)
    {
        var allDigits = input.Split(' ').Select(s => new Digit(s)).ToList();

        if (allDigits.Count != 10)
            throw new Exception("We need all 10 digits to hack their values.");

        FindEasyDigitsValues(allDigits);
        FindHarderDigitsValue(allDigits);

        return allDigits;
    }

    private void FindEasyDigitsValues(IList<Digit> digits)
    {
        foreach (var digit in digits)
        {
            if (digit.Segments.Length == 2)
                digit.Value = 1;
            else if (digit.Segments.Length == 4)
                digit.Value = 4;
            else if (digit.Segments.Length == 3)
                digit.Value = 7;
            else if (digit.Segments.Length == 7)
                digit.Value = 8;
        }
    }

    private void FindHarderDigitsValue(IList<Digit> digits)
    {
        var rightSegments = digits.Single(d => d.Value == 1).Segments.ToCharArray().ToList();
        var topSegment = digits.Single(d => d.Value == 7).Segments.Single(c => !rightSegments.Contains(c));
        var bottomSegment = Find9AndBottomSegment(digits, digits.Single(d => d.Value == 4).Segments, topSegment);
        var middleSegment = Find3AndMiddleSegment(digits, digits.Single(d => d.Value == 7).Segments, bottomSegment);
        Find0(digits, middleSegment);
        Find6(digits);
        Find5(digits);
        Find2(digits);
    }

    private static char Find9AndBottomSegment(IList<Digit> digits, string fourSegments, char topSegment)
    {
        var nine = digits.Single(d => d.Value == null && d.Segments.Length == 6 &&
            d.Segments.Contains(topSegment) && fourSegments.All(f => d.Segments.Contains(f)));
        nine.Value = 9;

        return nine.Segments.Single(s => s != topSegment && !fourSegments.Contains(s));
    }

    private static char Find3AndMiddleSegment(IList<Digit> digits, string sevenSegments, char bottomSegment)
    {
        var three = digits.Single(d => d.Value == null && d.Segments.Length == 5 &&
            d.Segments.Contains(bottomSegment) && sevenSegments.All(f => d.Segments.Contains(f)));
        three.Value = 3;

        return three.Segments.Single(s => s != bottomSegment && !sevenSegments.Contains(s));
    }

    private static void Find0(IList<Digit> digits, char middleSegment)
    {
        digits.Single(d => d.Value == null && d.Segments.Length == 6 &&
            !d.Segments.Contains(middleSegment)).Value = 0;
    }

    private static void Find6(IList<Digit> digits)
    {
        digits.Single(d => d.Value == null && d.Segments.Length == 6).Value = 6;
    }

    private static void Find5(IList<Digit> digits)
    {
        var six = digits.Single(d => d.Value == 6);
        digits.Single(d => d.Value == null && !d.Segments.Any(s => !six.Segments.Contains(s))).Value = 5;
    }

    private static void Find2(IList<Digit> digits)
    {
        digits.Single(d => d.Value == null).Value = 2;
    }
}
