namespace AoC2021.Day12;

internal class Day12Solver : IDaySolver
{
    private readonly ISeaCaveMapProvider _seaCaveMapProvider;

    public Day12Solver(ISeaCaveMapProvider seaCaveMapProvider)
    {
        _seaCaveMapProvider = seaCaveMapProvider;
    }

    public async Task<long> SolveBonusProblemAsync()
    {
        var seaCaveMap = await _seaCaveMapProvider.ProvideMapAsync();

        var allPaths = new List<string>();
        FindAllAvailablePaths(seaCaveMap, "start", "", allPaths, canVisitASmallCaveTwice: true);

        return allPaths.Count;
    }

    public async Task<long> SolveProblemAsync()
    {
        var seaCaveMap = await _seaCaveMapProvider.ProvideMapAsync();

        var allPaths = new List<string>();
        FindAllAvailablePaths(seaCaveMap, "start", "", allPaths, canVisitASmallCaveTwice: false);

        return allPaths.Count;
    }

    private static void FindAllAvailablePaths(IDictionary<string, SeaCave> seaCaveMap, string caveName, string cavePathSoFar, IList<string> allPaths, bool canVisitASmallCaveTwice)
    {
        var currentCave = seaCaveMap[caveName];
        var visitedASmallCaveTwice = false;

        if (!currentCave.IsWorthVisitingMoreThanOnce && cavePathSoFar.Split('-').Contains(caveName))
        {
            if (canVisitASmallCaveTwice && caveName != "start")
                visitedASmallCaveTwice = true;
            else
                return;
        }

        cavePathSoFar = $"{cavePathSoFar}-{caveName}";

        if (caveName == "end")
        {
            allPaths.Add(cavePathSoFar);
            return;
        }

        foreach (var connectedCaves in currentCave.ConnectedCaves)
            FindAllAvailablePaths(seaCaveMap, connectedCaves.Name, cavePathSoFar, allPaths, canVisitASmallCaveTwice && !visitedASmallCaveTwice);
    }
}
