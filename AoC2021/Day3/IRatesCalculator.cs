namespace AoC2021.Day3;

internal interface IRatesCalculator
{
    Task<(string gamma, string epsilon)> CalculatePowerConsumptionRatesAsync();
    Task<(string oxygen, string co2)> CalculateLifeSupportRatesAsync();
}
