namespace AoC2021.Day6;

internal class Day6Solver : IDaySolver
{
    private readonly ILanternfishSwarmPopulationCalculator _lanternfishSwarmPopulationCalculator;

    public Day6Solver(ILanternfishSwarmPopulationCalculator lanternfishSwarmPopulationCalculator)
    {
        _lanternfishSwarmPopulationCalculator = lanternfishSwarmPopulationCalculator;
    }

    public Task<long> SolveBonusProblemAsync()
    {
        return _lanternfishSwarmPopulationCalculator.CalculatePopulationAsync(256);
    }

    public Task<long> SolveProblemAsync()
    {
        return _lanternfishSwarmPopulationCalculator.CalculatePopulationAsync(80);
    }
}

