using AoC2021.Common;

namespace AoC2021.Day1;

internal class Day1Solver : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly IMesurementsCleaner _mesurementsCleaner;

    public Day1Solver(IRawInputProvider rawInputProvider, IMesurementsCleaner mesurementsCleaner)
    {
        _rawInputProvider = rawInputProvider;
        _mesurementsCleaner = mesurementsCleaner;
    }

    public async Task<int> SolveBonusProblemAsync()
    {
        var cleanMesurements = await _mesurementsCleaner.CleanMesurementsAsync(ParseRawInput(_rawInputProvider.ProvideRawInputAsync()));

        return await CalculateIncrements(() => cleanMesurements.ToAsyncEnumerable());
    }

    public Task<int> SolveProblemAsync()
    {
        return CalculateIncrements(() => ParseRawInput(_rawInputProvider.ProvideRawInputAsync()));
    }

    private async IAsyncEnumerable<int> ParseRawInput(IAsyncEnumerable<string> rawInput)
    {
        await foreach (var input in rawInput)
            yield return int.Parse(input);
    }

    private async Task<int> CalculateIncrements(Func<IAsyncEnumerable<int>> provideDepths)
    {
        var incrementsTotal = 0;
        int? lastDepth = null;

        await foreach (var currentDepth in provideDepths())
        {
            if (lastDepth != null && currentDepth > lastDepth)
                incrementsTotal++;

            lastDepth = currentDepth;
        }

        return incrementsTotal;
    }
}

