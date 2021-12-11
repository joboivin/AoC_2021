namespace AoC2021.Day9;

internal class Day9Solver : IDaySolver
{
    private const int AlreadyVisitedPoint = -1;
    private readonly IHeightmapProvider _heightmapProvider;

    public Day9Solver(IHeightmapProvider heightmapProvider)
    {
        _heightmapProvider = heightmapProvider;
    }

    public async Task<long> SolveBonusProblemAsync()
    {
        var heightmap = await _heightmapProvider.ProvideHeightMapAsync();
        var bassinSizes = new List<int>();
        var maximumX = heightmap[0].Count;
        var maximumY = heightmap.Count;

        for (var i = 0; i < maximumY; i++)
        {
            for (var j = 0; j < maximumX; j++)
            {
                if (heightmap[i][j] != 9 && heightmap[i][j] != AlreadyVisitedPoint)
                    bassinSizes.Add(CalculateBassinSize(i, j, maximumX, maximumY, heightmap));
            }
        }

        return bassinSizes.OrderByDescending(x => x).Take(3).Aggregate((current, product) => current * product);
    }

    private int CalculateBassinSize(int startingY, int startingX, int maximumX, int maximumY, List<List<int>> heightMap)
    {
        var bassinSize = 1;
        heightMap[startingY][startingX] = AlreadyVisitedPoint;

        if (startingY > 0 && heightMap[startingY - 1][startingX] != AlreadyVisitedPoint && heightMap[startingY - 1][startingX] != 9)
            bassinSize += CalculateBassinSize(startingY - 1, startingX, maximumX, maximumY, heightMap);

        if (startingY < maximumY - 1 && heightMap[startingY + 1][startingX] != AlreadyVisitedPoint && heightMap[startingY + 1][startingX] != 9)
            bassinSize += CalculateBassinSize(startingY + 1, startingX, maximumX, maximumY, heightMap);

        if (startingX > 0 && heightMap[startingY][startingX - 1] != AlreadyVisitedPoint && heightMap[startingY][startingX - 1] != 9)
            bassinSize += CalculateBassinSize(startingY, startingX - 1, maximumX, maximumY, heightMap);

        if (startingX < maximumX - 1 && heightMap[startingY][startingX + 1] != AlreadyVisitedPoint && heightMap[startingY][startingX + 1] != 9)
            bassinSize += CalculateBassinSize(startingY, startingX + 1, maximumX, maximumY, heightMap);

        return bassinSize;
    }

    public async Task<long> SolveProblemAsync()
    {
        var heightmap = await _heightmapProvider.ProvideHeightMapAsync();
        var sumOfLowPointsRiskLevels = 0;
        var maximumX = heightmap[0].Count;
        var maximumY = heightmap.Count;

        for (var i = 0; i < maximumY; i++)
        {
            for (var j = 0; j < maximumX; j++)
            {
                var currentPoint = heightmap[i][j];

                if ((i == 0 || currentPoint < heightmap[i - 1][j]) && (i == maximumY - 1 || currentPoint < heightmap[i + 1][j]) &&
                    (j == 0 || currentPoint < heightmap[i][j - 1]) && (j == maximumX - 1 || currentPoint < heightmap[i][j + 1]))
                    sumOfLowPointsRiskLevels += currentPoint + 1;
            }
        }

        return sumOfLowPointsRiskLevels;
    }
}
