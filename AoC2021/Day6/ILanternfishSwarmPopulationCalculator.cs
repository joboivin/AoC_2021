namespace AoC2021.Day6;

internal interface ILanternfishSwarmPopulationCalculator
{
    Task<long> CalculatePopulationAsync(int numberOfDays);
}
