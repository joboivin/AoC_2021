
namespace AoC2021.Day14
{
    internal interface IPolymerizer
    {
        Task<string> PolimerizeAsync(int numberOfSteps);
    }
}