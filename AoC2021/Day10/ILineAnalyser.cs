namespace AoC2021.Day10
{
    internal interface ILineAnalyser
    {
        LineStatus Analyse(string line);
        long CalculateLineCompletionScore(string line);
    }
}
