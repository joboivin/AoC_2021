namespace AoC2021.Day11;

internal interface IOctopusSimulator
{
    Task<long> SimulateOctopusesAsync(int numberOfSteps);
    Task<long> SimulateOctopusesComplexlyAsync();
}
