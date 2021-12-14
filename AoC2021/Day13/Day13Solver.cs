namespace AoC2021.Day13;

internal class Day13Solver : IDaySolver
{
    private readonly IPaperProvider _paperProvider;
    private readonly IConsole _console;

    public Day13Solver(IPaperProvider paperProvider, IConsole console)
    {
        _paperProvider = paperProvider;
        _console = console;
    }

    public async Task<long> SolveBonusProblemAsync()
    {
        var (paper, foldInstructions) = await _paperProvider.ProvidePaperAsync();
        var (maximumX, maximumY) = FoldPaper(paper, foldInstructions);

        DisplayCodeToConsole(paper, maximumX, maximumY);

        return -1; //Answer is not a number this time...
    }

    public async Task<long> SolveProblemAsync()
    {
        var (paper, foldInstructions) = await _paperProvider.ProvidePaperAsync();
        var (maximumX, maximumY) = FoldPaper(paper, new List<string> { foldInstructions.First() });

        return GetMarksCount(paper, maximumX, maximumY);
    }

    private (int maximumX, int maximumY) FoldPaper(bool[,] paper, IList<string> foldInstructions)
    {
        var maximumY = paper.GetUpperBound(0) + 1;
        var maximumX = paper.GetUpperBound(1) + 1;

        for (var i = 0; i < foldInstructions.Count; i++)
        {
            var (foldAgainstX, lineIndex) = InterpretFoldInstruction(foldInstructions[i]);

            if (foldAgainstX)
            {
                for (var x = lineIndex + 1; x < maximumX; x++)
                    for (var y = 0; y < maximumY; y++)
                    {
                        var newX = lineIndex - (x - lineIndex);

                        if (paper[y, x] && newX >= 0)
                            paper[y, newX] = true;
                    }

                maximumX = lineIndex;
            }
            else
            {
                for (var y = lineIndex + 1; y < maximumY; y++)
                    for (var x = 0; x < maximumX; x++)
                    {
                        var newY = lineIndex - (y - lineIndex);

                        if (paper[y, x] && newY >= 0)
                            paper[newY, x] = true;
                    }

                maximumY = lineIndex;
            }
        }

        return (maximumX, maximumY);
    }

    private static (bool foldAgainstX, int lineIndex) InterpretFoldInstruction(string foldInstruction)
    {
        var instructions = foldInstruction.Split('=');

        return (instructions[0].StartsWith("fold along x"), int.Parse(instructions[1]));
    }

    private static int GetMarksCount(bool[,] paper, int maximumX, int maximumY)
    {
        var marksCount = 0;

        for (var x = 0; x < maximumX; x++)
            for (var y = 0; y < maximumY; y++)
                if (paper[y, x])
                    marksCount++;

        return marksCount;
    }

    private void DisplayCodeToConsole(bool[,] paper, int maximumX, int maximumY)
    {
        for (var y = 0; y < maximumY; y++)
        {
            var line = "";

            for (var x = 0; x < maximumX; x++)
                line += paper[y, x] ? "#" : ".";

            _console.WriteLine(line);
        }
    }
}
