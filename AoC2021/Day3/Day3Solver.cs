namespace AoC2021.Day3;

internal class Day3Solver : IDaySolver
{
    private readonly IRatesCalculator _ratesCalculator;

    public Day3Solver(IRatesCalculator ratesCalculator)
    {
        _ratesCalculator = ratesCalculator;
    }

    public async Task<int> SolveBonusProblemAsync()
    {
        var (oxygen, co2) = await _ratesCalculator.CalculateLifeSupportRatesAsync();

        return (Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2));
    }

    public async Task<int> SolveProblemAsync()
    {
        var (gamma, epsilon) = await _ratesCalculator.CalculatePowerConsumptionRatesAsync();

        return (Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));
    }
}
