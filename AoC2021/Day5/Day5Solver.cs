using AoC2021.Common;

namespace AoC2021.Day5;

internal class Day5Solver : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly IHydrothermalVentPointsProvider _hydrothermalVentPointsProvider;

    public Day5Solver(IRawInputProvider rawInputProvider, IHydrothermalVentPointsProvider hydrothermalVentPointsProvider)
    {
        _rawInputProvider = rawInputProvider;
        _hydrothermalVentPointsProvider = hydrothermalVentPointsProvider;
    }

    public Task<int> SolveBonusProblemAsync()
    {
        return SolveProblemAsync((line) => _hydrothermalVentPointsProvider.ProvideAllPoints(line));
    }

    public Task<int> SolveProblemAsync()
    {
        return SolveProblemAsync((line) => _hydrothermalVentPointsProvider.ProvidePoints(line));
    }

    private async Task<int> SolveProblemAsync(Func<string, IList<(int, int)>> providePoints)
    {
        var oceanPositions = new Dictionary<(int, int), int>();

        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
        {
            foreach (var ventPoint in providePoints(line))
                if (oceanPositions.ContainsKey(ventPoint))
                    oceanPositions[ventPoint]++;
                else
                    oceanPositions.Add(ventPoint, 1);
        }

        return oceanPositions.Values.Count(v => v >= 2);
    }
}
