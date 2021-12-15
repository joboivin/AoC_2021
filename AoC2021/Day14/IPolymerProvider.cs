
namespace AoC2021.Day14
{
    internal interface IPolymerProvider
    {
        Task<(string polymerTemplate, IDictionary<string, string> pairInsertionRules)> ProvidePolymerAsync();
    }
}