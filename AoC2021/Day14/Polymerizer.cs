namespace AoC2021.Day14;

internal class Polymerizer : IPolymerizer
{
    private readonly IPolymerProvider _polymerProvider;

    public Polymerizer(IPolymerProvider polymerProvider)
    {
        _polymerProvider = polymerProvider;
    }

    public async Task<string> PolimerizeAsync(int numberOfSteps)
    {
        var (polymerTemplate, pairInsertionRules) = await _polymerProvider.ProvidePolymerAsync();
        var result = polymerTemplate;

        for (var i = 0; i < numberOfSteps; i++)
        {
            var tempResult = "";

            for (var j = 0; j < result.Length - 1; j++)
            {
                var pair = result.Substring(j, 2);

                tempResult += $"{pair[0]}{pairInsertionRules[pair]}";
            }

            result = tempResult + result.Last();
        }

        return result;
    }
}
