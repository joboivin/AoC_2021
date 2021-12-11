namespace AoC2021.Day11;

internal class Day11Solver : IDaySolver
{
    private readonly IOctopusSimulator _octopusSimulator;

    public Day11Solver(IOctopusSimulator octopusSimulator)
    {
        _octopusSimulator = octopusSimulator;
    }

    public Task<long> SolveBonusProblemAsync()
    {
        return _octopusSimulator.SimulateOctopusesComplexlyAsync();
    }

    public Task<long> SolveProblemAsync()
    {
        return _octopusSimulator.SimulateOctopusesAsync(100);
    }
}
