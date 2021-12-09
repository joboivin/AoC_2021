using AoC2021.Common;

namespace AoC2021.Day8;

internal class Day8Solver : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly IDigitValuesFinder _digitValuesFinder;
    private readonly List<int> _easyDigits = new List<int> { 1, 4, 7, 8 };


    public Day8Solver(IRawInputProvider rawInputProvider, IDigitValuesFinder digitValuesFinder)
    {
        _rawInputProvider = rawInputProvider;
        _digitValuesFinder = digitValuesFinder;
    }

    public async Task<long> SolveBonusProblemAsync()
    {
        var sumOfOutputValues = 0;

        await SolveProblemAsync((digits, outputValues) =>
        {
            var outputValue = 0;

            for (var i = 0; i < outputValues.Length; i++)
                outputValue = 10 * outputValue + FindDigit(digits, outputValues[i])!.Value;

            sumOfOutputValues += outputValue;
        });

        return sumOfOutputValues;
    }

    public async Task<long> SolveProblemAsync()
    {
        var numberOfEasyDigitsInOutputValue = 0;

        await SolveProblemAsync((digits, outputValues) =>
            numberOfEasyDigitsInOutputValue += outputValues.Count(v =>
            {
                var digit = FindDigit(digits, v);

                return _easyDigits.Contains(digit!.Value);
            }));

        return numberOfEasyDigitsInOutputValue;
    }

    private async Task SolveProblemAsync(Action<IList<Digit>, string[]> processOutputValues)
    {
        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
        {
            var partsOfLine = line.Split(" | ");
            var signalPatterns = partsOfLine[0];
            var outputValues = partsOfLine[1].Split(' ');
            var digits = _digitValuesFinder.FindDigitValues(signalPatterns);

            processOutputValues(digits, outputValues);
        }
    }

    private static int? FindDigit(IList<Digit> digits, string v)
    {
        return digits.Single(d => d.Segments.OrderBy(x => x).SequenceEqual(v.OrderBy(x => x))).Value;
    }
}
