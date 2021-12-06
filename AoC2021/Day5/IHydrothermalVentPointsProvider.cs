namespace AoC2021.Day5;

internal interface IHydrothermalVentPointsProvider
{
    IList<(int horizontal, int vertical)> ProvidePoints(string line);
    IList<(int horizontal, int vertical)> ProvideAllPoints(string line);
}
