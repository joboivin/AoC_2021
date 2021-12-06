using AoC2021.Common;

namespace AoC2021.Day6;

internal class LanternfishSwarmPopulationCalculator : ILanternfishSwarmPopulationCalculator
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly ILanternfishReproductionCalculator _lanternfishReproductionCalculator;

    public LanternfishSwarmPopulationCalculator(IRawInputProvider rawInputProvider, ILanternfishReproductionCalculator lanternfishReproductionCalculator)
    {
        _rawInputProvider = rawInputProvider;
        _lanternfishReproductionCalculator = lanternfishReproductionCalculator;
    }

    public async Task<long> CalculatePopulationAsync(int numberOfDays)
    {
        var knownFinalPopulation = new Dictionary<int, Task<long>>();
        var numberOfLanternfishWithThisInternalTimer = new Dictionary<int, long>();
        var input = await _rawInputProvider.ProvideRawInputAsync().FirstAsync(); //Only 1 line for this puzzle

        foreach (var lanternfishInternalTimer in input.Split(','))
        {
            var internalTimer = int.Parse(lanternfishInternalTimer);
            if (knownFinalPopulation.ContainsKey(internalTimer))
                numberOfLanternfishWithThisInternalTimer[internalTimer]++;
            else
            {
                knownFinalPopulation.Add(internalTimer, Task.Run(() => _lanternfishReproductionCalculator.CalculateReproduction(internalTimer, numberOfDays)));
                numberOfLanternfishWithThisInternalTimer.Add(internalTimer, 1);
            }
        }

        await Task.WhenAll(knownFinalPopulation.Values);

        return knownFinalPopulation.Sum(kv => kv.Value.Result * numberOfLanternfishWithThisInternalTimer[kv.Key]);
    }
}
