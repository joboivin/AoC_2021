using AoC2021.Common;

namespace AoC2021.Day9;

internal class HeightmapProvider : IHeightmapProvider
{
    private readonly IRawInputProvider _rawInputProvider;

    public HeightmapProvider(IRawInputProvider rawInputProvider)
    {
        _rawInputProvider = rawInputProvider;
    }

    public Task<List<List<int>>> ProvideHeightMapAsync()
    {
        return _rawInputProvider.ProvideRawInputAsync().Select(line =>
            line.Select(x => int.Parse(x.ToString())).ToList()).ToListAsync().AsTask();
    }
}
