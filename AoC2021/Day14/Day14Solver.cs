namespace AoC2021.Day14;

internal class Day14Solver : IDaySolver
{
    private readonly IPolymerizer _polymerizer;
    private readonly ISimplePolymerizer _simplePolymerizer;

    public Day14Solver(IPolymerizer polymerizer, ISimplePolymerizer simplePolymerizer)
    {
        _polymerizer = polymerizer;
        _simplePolymerizer = simplePolymerizer;
    }

    public Task<long> SolveBonusProblemAsync()
    {
        return _simplePolymerizer.PolymerizeAsync(40);
    }

    public Task<long> SolveProblemAsync()
    {
        //Keeping old solution for comparaison purposes
        return SolveProblemAsync(10);
    }

    private async Task<long> SolveProblemAsync(int numberOfSteps)
    {
        var polymer = await _polymerizer.PolimerizeAsync(numberOfSteps);
        var elementOccurences = new Dictionary<char, int>();

        foreach (var element in polymer)
        {
            if (elementOccurences.ContainsKey(element))
                elementOccurences[element]++;
            else
                elementOccurences[element] = 1;
        }

        var elementOccurencesValues = elementOccurences.Values.OrderBy(x => x);

        return elementOccurencesValues.Last() - elementOccurencesValues.First();
    }
}
