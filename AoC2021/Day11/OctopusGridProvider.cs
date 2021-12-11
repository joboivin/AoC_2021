using AoC2021.Common;

namespace AoC2021.Day11;

internal class OctopusGridProvider : IOctopusGridProvider
{
    public const int GridDimension = 10;

    private readonly IRawInputProvider _rawInputProvider;

    public OctopusGridProvider(IRawInputProvider rawInputProvider)
    {
        _rawInputProvider = rawInputProvider;
    }

    public async Task<IList<Octopus>> ProvideOctopusesAsync(Action octopusFlash)
    {
        var octopusGrid = await ProvideOctopusGridAsync(octopusFlash);
        SetAdjacentOctopuses(octopusGrid);

        return ConvertToEnumerable(octopusGrid).ToList();
    }

    private async Task<Octopus[,]> ProvideOctopusGridAsync(Action octopusFlash)
    {
        var grid = new Octopus[GridDimension, GridDimension];
        var lineIndex = 0;

        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
        {
            if (line.Length != GridDimension)
                throw new Exception($"Line {line} does not contain 10 octopuses");

            for (var i = 0; i < GridDimension; i++)
                grid[lineIndex, i] = new Octopus(int.Parse(line.Substring(i, 1)), octopusFlash);

            lineIndex++;
        }

        if (lineIndex != GridDimension)
            throw new Exception("Input does contain 10 octopus lines");

        return grid;
    }

    private static void SetAdjacentOctopuses(Octopus[,] octopusGrid)
    {
        for (var i = 0; i < GridDimension; i++)
        {
            for (var j = 0; j < GridDimension; j++)
            {
                var hasTopAdjacents = i != 0;
                var hasBottomAdjacents = i != GridDimension - 1;
                var hasLeftAdjacents = j != 0;
                var hasRightAdjacents = j != GridDimension - 1;

                if (hasTopAdjacents)
                {
                    octopusGrid[i, j].AddAdjacentOctopus(octopusGrid[i - 1, j]);

                    if (hasLeftAdjacents)
                        octopusGrid[i, j].AddAdjacentOctopus(octopusGrid[i - 1, j - 1]);

                    if (hasRightAdjacents)
                        octopusGrid[i, j].AddAdjacentOctopus(octopusGrid[i - 1, j + 1]);
                }

                if (hasBottomAdjacents)
                {
                    octopusGrid[i, j].AddAdjacentOctopus(octopusGrid[i + 1, j]);

                    if (hasLeftAdjacents)
                        octopusGrid[i, j].AddAdjacentOctopus(octopusGrid[i + 1, j - 1]);

                    if (hasRightAdjacents)
                        octopusGrid[i, j].AddAdjacentOctopus(octopusGrid[i + 1, j + 1]);
                }

                if (hasLeftAdjacents)
                    octopusGrid[i, j].AddAdjacentOctopus(octopusGrid[i, j - 1]);

                if (hasRightAdjacents)
                    octopusGrid[i, j].AddAdjacentOctopus(octopusGrid[i, j + 1]);
            }
        }
    }

    private static IEnumerable<Octopus> ConvertToEnumerable(Octopus[,] octopusGrid)
    {
        for (var i = 0; i < GridDimension; i++)
            for (var j = 0; j < GridDimension; j++)
                yield return octopusGrid[i, j];
    }
}
