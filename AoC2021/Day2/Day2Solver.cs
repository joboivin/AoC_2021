using AoC2021.Common;

namespace AoC2021.Day2;

internal class Day2Solver : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly IPositionCalculator _positionCalculator;

    public Day2Solver(IRawInputProvider rawInputProvider, IPositionCalculator positionCalculator)
    {
        _rawInputProvider = rawInputProvider;
        _positionCalculator = positionCalculator;
    }

    public async Task<int> SolveBonusProblemAsync()
    {
        var position = await _positionCalculator.CalculateAdvancedPositionAsync(_rawInputProvider.ProvideRawInputAsync());

        return position.horizontal * position.vertical;
    }

    public async Task<int> SolveProblemAsync()
    {
        var position = await _positionCalculator.CalculateBasicPositionAsync(_rawInputProvider.ProvideRawInputAsync());

        return position.horizontal * position.vertical;
    }
}

