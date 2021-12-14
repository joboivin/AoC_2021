using AoC2021.Common;

namespace AoC2021.Day13;

internal class PaperProvider : IPaperProvider
{
    private readonly IRawInputProvider _rawInputProvider;

    public PaperProvider(IRawInputProvider rawInputProvider)
    {
        _rawInputProvider = rawInputProvider;
    }

    public async Task<(bool[,] paper, IList<string> foldInstructions)> ProvidePaperAsync()
    {
        var (marksPositions, maximumX, maximumY, foldInstructions) = await ProvideRawPaperAsync();

        return (ConvertToPaper(marksPositions, maximumX, maximumY), foldInstructions);
    }

    private async Task<(IList<(int x, int y)> marksPositions, int maximumX, int maximumY, IList<string> foldInstructions)> ProvideRawPaperAsync()
    {
        var maximumX = 0;
        var maximumY = 0;
        var marksPositions = new List<(int, int)>();
        var foldInstructions = new List<string>();
        var areMarksPositionsFinished = false;

        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
        {
            if (string.IsNullOrEmpty(line))
                areMarksPositionsFinished = true;
            else
            {
                if (areMarksPositionsFinished)
                    foldInstructions.Add(line);
                else
                {
                    var positions = line.Split(',');
                    var x = int.Parse(positions[0]);
                    var y = int.Parse(positions[1]);

                    if (x > maximumX)
                        maximumX = x;

                    if (y > maximumY)
                        maximumY = y;

                    marksPositions.Add((x, y));
                }
            }
        }

        return (marksPositions, maximumX, maximumY, foldInstructions);
    }

    private static bool[,] ConvertToPaper(IList<(int x, int y)> marksPositions, int maximumX, int maximumY)
    {
        var paper = new bool[maximumY + 1, maximumX + 1];

        foreach (var markPosition in marksPositions)
            paper[markPosition.y, markPosition.x] = true;

        return paper;
    }
}
