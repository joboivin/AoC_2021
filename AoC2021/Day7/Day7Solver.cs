using AoC2021.Common;

namespace AoC2021.Day7;

internal class Day7Solver : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider;

    public Day7Solver(IRawInputProvider rawInputProvider)
    {
        _rawInputProvider = rawInputProvider;
    }

    public Task<long> SolveBonusProblemAsync()
    {
        var knownFuelCosts = new Dictionary<int, int>();

        return SolveProblemAsync(movement => CalculateFuelCost(movement, knownFuelCosts));
    }

    public Task<long> SolveProblemAsync()
    {
        return SolveProblemAsync(movement => movement);
    }

    private async Task<long> SolveProblemAsync(Func<int, int> calculateFuelCostForMovement)
    {
        var input = await _rawInputProvider.ProvideRawInputAsync().FirstAsync(); //Only 1 line for this puzzle
        int? smallestPosition = null;
        int? largestPosition = null;
        int? smallestFuelCost = null;
        var numberOfCrabByPosition = new Dictionary<int, int>();

        foreach (var position in input.Split(','))
        {
            var numericalPosition = int.Parse(position);

            if (numericalPosition < (smallestPosition ?? int.MaxValue))
                smallestPosition = numericalPosition;

            if (numericalPosition > (largestPosition ?? int.MinValue))
                largestPosition = numericalPosition;

            if (numberOfCrabByPosition.ContainsKey(numericalPosition))
                numberOfCrabByPosition[numericalPosition]++;
            else
                numberOfCrabByPosition.Add(numericalPosition, 1);
        }

        for (var i = smallestPosition.Value; i <= largestPosition; i++)
        {
            var fuelCost = 0;

            foreach (var kv in numberOfCrabByPosition)
                fuelCost += calculateFuelCostForMovement(Math.Abs(kv.Key - i)) * kv.Value;

            if (fuelCost < (smallestFuelCost ?? int.MaxValue))
                smallestFuelCost = fuelCost;
        }

        return smallestFuelCost.Value;
    }

    private int CalculateFuelCost(int movement, Dictionary<int, int> knownFuelCosts)
    {
        if (knownFuelCosts.ContainsKey(movement))
            return knownFuelCosts[movement];

        if (movement == 0)
            return 0;

        var fuelCost = CalculateFuelCost(movement - 1, knownFuelCosts) + movement;
        knownFuelCosts.Add(movement, fuelCost);

        return fuelCost;
    }
}
