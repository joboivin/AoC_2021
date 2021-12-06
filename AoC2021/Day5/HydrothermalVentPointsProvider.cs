using System.Text.RegularExpressions;

namespace AoC2021.Day5;

internal class HydrothermalVentPointsProvider : IHydrothermalVentPointsProvider
{
    private const string PointsPattern = "^(\\d*),(\\d*) -> (\\d*),(\\d*)$";

    public IList<(int horizontal, int vertical)> ProvidePoints(string line)
    {
        var pointsMatch = new Regex(PointsPattern).Match(line);

        if (!pointsMatch.Success)
            throw new Exception($"Line {line} doesn't follow points pattern.");

        return ProvidePoints(pointsMatch.Groups, false);
    }

    public IList<(int horizontal, int vertical)> ProvideAllPoints(string line)
    {
        var pointsMatch = new Regex(PointsPattern).Match(line);

        if (!pointsMatch.Success)
            throw new Exception($"Line {line} doesn't follow points pattern.");

        return ProvidePoints(pointsMatch.Groups, true);
    }

    private IList<(int horizontal, int vertical)> ProvidePoints(GroupCollection groups, bool includeDiagonals)
    {
        var horizontalStart = int.Parse(groups[1].Value);
        var verticalStart = int.Parse(groups[2].Value);
        var horizontalEnd = int.Parse(groups[3].Value);
        var verticalEnd = int.Parse(groups[4].Value);

        if (horizontalStart == horizontalEnd)
            return ProvideStraigthLinePoints(horizontalStart, verticalStart, verticalEnd, isHorizontal: true).ToList();
        else if (verticalStart == verticalEnd)
            return ProvideStraigthLinePoints(verticalStart, horizontalStart, horizontalEnd, isHorizontal: false).ToList();

        if (includeDiagonals)
            return ProvideDiagonalsPoints(horizontalStart, verticalStart, horizontalEnd, verticalEnd).ToList();

        return new List<(int horizontal, int vertical)>();
    }

    private IEnumerable<(int horizontal, int vertical)> ProvideStraigthLinePoints(int straigthPoint, int start, int end, bool isHorizontal)
    {
        var smallestPosition = Math.Min(start, end);
        var largestPosition = Math.Max(start, end);

        for (var i = smallestPosition; i <= largestPosition; i++)
            if (isHorizontal)
                yield return (straigthPoint, i);
            else
                yield return (i, straigthPoint);
    }

    private IEnumerable<(int horizontal, int vertical)> ProvideDiagonalsPoints(int horizontalStart, int verticalStart, int horizontalEnd, int verticalEnd)
    {
        int horizontalIncrease = horizontalStart < horizontalEnd ? 1 : -1;
        int verticalIncrease = verticalStart < verticalEnd ? 1 : -1;
        int lineLength = Math.Abs(horizontalEnd - horizontalStart);

        for (var i = 0; i <= lineLength; i++)
            yield return (horizontalStart + i * horizontalIncrease, verticalStart + i * verticalIncrease);
    }
}
