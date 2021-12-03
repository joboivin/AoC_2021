namespace AoC2021.Day1;

internal class MesurementsCleaner : IMesurementsCleaner
{
    public async Task<IList<int>> CleanMesurementsAsync(IAsyncEnumerable<int> dirtyMesurements)
    {
        var cleanMesurements = new List<int>();
        var index = 0;

        await foreach (var mesurement in dirtyMesurements)
        {
            cleanMesurements.Add(mesurement);

            if (index > 0)
                cleanMesurements[index - 1] += mesurement;

            if (index > 1)
                cleanMesurements[index - 2] += mesurement;

            index++;
        }

        RemoveIncompleteMesurements(cleanMesurements, index);

        return cleanMesurements;
    }

    private void RemoveIncompleteMesurements(IList<int> mesurements, int mesurementsCount)
    {
        mesurements.RemoveAt(mesurementsCount - 1);
        mesurements.RemoveAt(mesurementsCount - 2);
    }
}

