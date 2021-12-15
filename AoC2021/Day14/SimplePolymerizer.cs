namespace AoC2021.Day14;

internal class SimplePolymerizer : ISimplePolymerizer
{
    private readonly IPolymerProvider _polymerProvider;

    public SimplePolymerizer(IPolymerProvider polymerProvider)
    {
        _polymerProvider = polymerProvider;
    }

    public async Task<long> PolymerizeAsync(int numberOfSteps)
    {
        var (polymerTemplate, pairInsertionRules) = await _polymerProvider.ProvidePolymerAsync();

        var polymerizationResult = Polymerize(InitializePairCount(polymerTemplate), pairInsertionRules, numberOfSteps);

        return CalculateElementDifference(polymerizationResult, polymerTemplate.Last());
    }

    private IDictionary<string, long> InitializePairCount(string polymerTemplate)
    {
        var pairCount = new Dictionary<string, long>();

        for (var i = 0; i < polymerTemplate.Length - 1; i++)
        {
            var pair = polymerTemplate.Substring(i, 2);

            if (pairCount.ContainsKey(pair))
                pairCount[pair]++;
            else
                pairCount[pair] = 1;
        }

        return pairCount;
    }

    private IDictionary<string, long> Polymerize(IDictionary<string, long> initialPairCount, IDictionary<string, string> pairInsertionRules, int numberOfSteps)
    {
        var pairCounts = initialPairCount;

        for (var i = 0; i < numberOfSteps; i++)
        {
            var tempPairCount = new Dictionary<string, long>();

            foreach (var kv in pairCounts)
            {
                var insertion = pairInsertionRules[kv.Key];
                var firstNewPair = $"{kv.Key[0]}{insertion}";
                var secondNewPair = $"{insertion}{kv.Key[1]}";

                if (tempPairCount.ContainsKey(firstNewPair))
                    tempPairCount[firstNewPair] += kv.Value;
                else
                    tempPairCount[firstNewPair] = kv.Value;

                if (tempPairCount.ContainsKey(secondNewPair))
                    tempPairCount[secondNewPair] += kv.Value;
                else
                    tempPairCount[secondNewPair] = kv.Value;
            }

            pairCounts = tempPairCount;
        }

        return pairCounts;
    }

    private long CalculateElementDifference(IDictionary<string, long> polymerizationResult, char lastCharOfPolymerTemplate)
    {
        var elementOccurences = new Dictionary<char, long>();

        foreach (var kv in polymerizationResult)
        {
            var elementToConsider = kv.Key.First();

            if (elementOccurences.ContainsKey(elementToConsider))
                elementOccurences[elementToConsider] += kv.Value;
            else
                elementOccurences[elementToConsider] = kv.Value;
        }

        //To account for last char of polymer, because we only consider first char of every pair
        elementOccurences[lastCharOfPolymerTemplate]++;

        var elementOccurencesValues = elementOccurences.Values.OrderBy(x => x);

        return elementOccurencesValues.Last() - elementOccurencesValues.First();
    }
}
