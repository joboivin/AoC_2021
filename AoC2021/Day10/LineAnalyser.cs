namespace AoC2021.Day10;

internal class LineAnalyser : ILineAnalyser
{
    private static readonly IList<char> OpeningBrackets = new List<char> { '(', '[', '{', '<' };
    private static readonly IDictionary<char, int> BracketScore = new Dictionary<char, int>
    {
        { '(', 1 }, {'[', 2}, {'{', 3}, {'<', 4}
    };

    public LineStatus Analyse(string line)
    {
        var brackets = new Stack<char>();

        foreach (var bracket in line)
        {
            if (OpeningBrackets.Contains(bracket))
                brackets.Push(bracket);
            else
            {
                var matchingBracket = brackets.Pop();

                if (bracket == ')' && matchingBracket != '(')
                    return LineStatus.IllegalParenthese;

                if (bracket == ']' && matchingBracket != '[')
                    return LineStatus.IllegalSquareBracket;

                if (bracket == '}' && matchingBracket != '{')
                    return LineStatus.IllegalBrace;

                if (bracket == '>' && matchingBracket != '<')
                    return LineStatus.IllegalChevron;
            }
        }

        return brackets.Any() ? LineStatus.Incomplete : LineStatus.Good;
    }

    public long CalculateLineCompletionScore(string line)
    {
        var brackets = new Stack<char>();

        foreach (var bracket in line)
        {
            if (OpeningBrackets.Contains(bracket))
                brackets.Push(bracket);
            else
                brackets.Pop();
        }

        var lineCompletionScore = 0L;

        while (brackets.Count > 0)
        {
            var lonelyBracket = brackets.Pop();

            lineCompletionScore *= 5;
            lineCompletionScore += BracketScore[lonelyBracket];
        }

        return lineCompletionScore;
    }
}
