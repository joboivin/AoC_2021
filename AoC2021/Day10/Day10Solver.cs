using AoC2021.Common;

namespace AoC2021.Day10;

internal class Day10Solver : IDaySolver
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly ILineAnalyser _lineAnalyser;

    public Day10Solver(IRawInputProvider rawInputProvider, ILineAnalyser lineAnalyser)
    {
        _rawInputProvider = rawInputProvider;
        _lineAnalyser = lineAnalyser;
    }

    public async Task<long> SolveBonusProblemAsync()
    {
        var allCompletionScores = new List<long>();

        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
        {
            var lineStatus = _lineAnalyser.Analyse(line);

            if (lineStatus == LineStatus.Incomplete)
                allCompletionScores.Add(_lineAnalyser.CalculateLineCompletionScore(line));
        }

        var numberOfCompletionScores = allCompletionScores.Count;

        return allCompletionScores.OrderBy(x => x).Skip(numberOfCompletionScores / 2).First();
    }

    public async Task<long> SolveProblemAsync()
    {
        var totalSyntaxErrorScore = 0;

        await foreach (var line in _rawInputProvider.ProvideRawInputAsync())
        {
            var lineStatus = _lineAnalyser.Analyse(line);

            if (lineStatus == LineStatus.IllegalParenthese)
                totalSyntaxErrorScore += 3;
            else if (lineStatus == LineStatus.IllegalSquareBracket)
                totalSyntaxErrorScore += 57;
            else if (lineStatus == LineStatus.IllegalBrace)
                totalSyntaxErrorScore += 1197;
            else if (lineStatus == LineStatus.IllegalChevron)
                totalSyntaxErrorScore += 25137;
        }

        return totalSyntaxErrorScore;
    }
}
