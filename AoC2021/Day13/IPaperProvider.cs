
namespace AoC2021.Day13
{
    internal interface IPaperProvider
    {
        Task<(bool[,] paper, IList<string> foldInstructions)> ProvidePaperAsync();
    }
}