using AoC2021.Common;

namespace AoC2021.Day3;

internal class RatesCalculator : IRatesCalculator
{
    private readonly IRawInputProvider _rawInputProvider;

    public RatesCalculator(IRawInputProvider rawInputProvider)
    {
        _rawInputProvider = rawInputProvider;
    }

    public async Task<(string gamma, string epsilon)> CalculatePowerConsumptionRatesAsync()
    {
        var mostCommonBytes = await CalculateMostCommonBytesAsync();
        var gammaRate = new char[mostCommonBytes.Length];
        var epsilonRate = new char[mostCommonBytes.Length];

        for (var i = 0; i < mostCommonBytes.Length; i++)
        {
            if (mostCommonBytes[i] > 0)
            {
                gammaRate[i] = '1';
                epsilonRate[i] = '0';
            }
            else if (mostCommonBytes[i] < 0)
            {
                gammaRate[i] = '0';
                epsilonRate[i] = '1';
            }
            else
                throw new Exception("Unhandled situation, same number of 0s and 1s");
        }

        return (new string(gammaRate), new string(epsilonRate));
    }

    public async Task<(string oxygen, string co2)> CalculateLifeSupportRatesAsync()
    {
        var lines = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();
        var oxygenLines = lines;
        var co2Lines = lines;
        var positionsTotal = oxygenLines.First().Length;

        for (var i = 0; i < positionsTotal; i++)
        {
            if (oxygenLines.Count > 1)
            {
                var mostCommonByteForOxygen = CalculateMostCommonByte(i, oxygenLines);
                oxygenLines = oxygenLines.Where(l => l[i] == (mostCommonByteForOxygen ?? '1')).ToList();
            }

            if (co2Lines.Count > 1)
            {
                var mostCommonByteForCO2 = CalculateMostCommonByte(i, co2Lines);
                co2Lines = co2Lines.Where(l => l[i] != (mostCommonByteForCO2 ?? '1')).ToList();
            }

            if (oxygenLines.Count == 1 && co2Lines.Count == 1)
                break;
        }

        return (oxygenLines.Single(), co2Lines.Single());
    }

    private async Task<int[]> CalculateMostCommonBytesAsync()
    {
        var lines = _rawInputProvider.ProvideRawInputAsync();
        var mostCommonBytes = new int[(await lines.FirstAsync()).Length];

        await foreach (var line in lines)
        {
            for (var i = 0; i < mostCommonBytes.Length; i++)
            {
                if (line[i] == '1')
                    mostCommonBytes[i]++;
                else
                    mostCommonBytes[i]--;
            }
        }

        return mostCommonBytes;
    }

    private char? CalculateMostCommonByte(int position, IEnumerable<string> lines)
    {
        var mostCommonByteCalculator = 0;

        foreach (var line in lines)
        {
            if (line[position] == '1')
                mostCommonByteCalculator++;
            else
                mostCommonByteCalculator--;
        }

        if (mostCommonByteCalculator > 0)
            return '1';

        return mostCommonByteCalculator < 0 ? '0' : null;
    }
}
