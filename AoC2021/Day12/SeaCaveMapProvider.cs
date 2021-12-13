using AoC2021.Common;

namespace AoC2021.Day12;

internal class SeaCaveMapProvider : ISeaCaveMapProvider
{
    private readonly IRawInputProvider _rawInputProvider;

    public SeaCaveMapProvider(IRawInputProvider rawInputProvider)
    {
        _rawInputProvider = rawInputProvider;
    }

    public async Task<IDictionary<string, SeaCave>> ProvideMapAsync()
    {
        var seaCavesMap = new Dictionary<string, SeaCave>();

        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
            AddSeaCavesToMap(seaCavesMap, line);

        return seaCavesMap;
    }

    private static void AddSeaCavesToMap(IDictionary<string, SeaCave> seaCavesMap, string seaCavesInformation)
    {
        var cavesNames = seaCavesInformation.Split('-');

        if (!seaCavesMap.ContainsKey(cavesNames[0]))
            seaCavesMap[cavesNames[0]] = new SeaCave(cavesNames[0]);

        if (!seaCavesMap.ContainsKey(cavesNames[1]))
            seaCavesMap[cavesNames[1]] = new SeaCave(cavesNames[1]);

        seaCavesMap[cavesNames[0]].AddConnectedCave(seaCavesMap[cavesNames[1]]);
        seaCavesMap[cavesNames[1]].AddConnectedCave(seaCavesMap[cavesNames[0]]);
    }
}
