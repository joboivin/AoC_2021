
namespace AoC2021.Day12
{
    internal interface ISeaCaveMapProvider
    {
        Task<IDictionary<string, SeaCave>> ProvideMapAsync();
    }
}