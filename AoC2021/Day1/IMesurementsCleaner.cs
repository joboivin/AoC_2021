namespace AoC2021.Day1;

internal interface IMesurementsCleaner
{
    Task<IList<int>> CleanMesurementsAsync(IAsyncEnumerable<int> dirtyMesurements);
}

