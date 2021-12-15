using AoC2021.Common;

namespace AoC2021.Day14;

internal class PolymerProvider : IPolymerProvider
{
    private readonly IRawInputProvider _rawInputProvider;

    public PolymerProvider(IRawInputProvider rawInputProvider)
    {
        _rawInputProvider = rawInputProvider;
    }

    public async Task<(string polymerTemplate, IDictionary<string, string> pairInsertionRules)> ProvidePolymerAsync()
    {
        var input = await _rawInputProvider.ProvideRawInputAsync().ToListAsync();
        var polymerTemplate = input[0];
        var pairInsertionRules = new Dictionary<string, string>();

        //1 blank line between template and rules, so starting index is 2
        for (var i = 2; i < input.Count; i++)
        {
            var parts = input[i].Split(" -> ");
            pairInsertionRules[parts[0]] = $"{parts[1]}";
        }

        return (polymerTemplate, pairInsertionRules);
    }
}
