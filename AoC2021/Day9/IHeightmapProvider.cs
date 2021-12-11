namespace AoC2021.Day9;

internal interface IHeightmapProvider
{
    Task<List<List<int>>> ProvideHeightMapAsync();
}
