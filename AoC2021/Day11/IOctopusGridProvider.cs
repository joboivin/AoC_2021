namespace AoC2021.Day11;

internal interface IOctopusGridProvider
{
    Task<IList<Octopus>> ProvideOctopusesAsync(Action octopusFlash);
}
