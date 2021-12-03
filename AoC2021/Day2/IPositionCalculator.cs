namespace AoC2021.Day2;

internal interface IPositionCalculator
{
    Task<(int horizontal, int vertical)> CalculateBasicPositionAsync(IAsyncEnumerable<string> commands);
    Task<(int horizontal, int vertical)> CalculateAdvancedPositionAsync(IAsyncEnumerable<string> commands);
}
