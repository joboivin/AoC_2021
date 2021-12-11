namespace AoC2021.Day11;

internal class OctopusSimulator : IOctopusSimulator
{
    private readonly IOctopusGridProvider _octopusGridProvider;

    public OctopusSimulator(IOctopusGridProvider octopusGridProvider)
    {
        _octopusGridProvider = octopusGridProvider;
    }

    public async Task<long> SimulateOctopusesAsync(int numberOfSteps)
    {
        var numberOfFlashes = 0;
        var octopuses = await _octopusGridProvider.ProvideOctopusesAsync(() => numberOfFlashes++);

        for (var i = 0; i < numberOfSteps; i++)
        {
            foreach (var octopus in octopuses)
                octopus.IncreaseEnergy();

            foreach (var octopus in octopuses)
                octopus.PerformEndOfStep();
        }

        return numberOfFlashes;
    }

    public async Task<long> SimulateOctopusesComplexlyAsync()
    {
        var numberOfSimulataneousFlashes = 0;
        var octopuses = await _octopusGridProvider.ProvideOctopusesAsync(() => numberOfSimulataneousFlashes++);
        var numberOfSteps = 1;

        while (true)
        {
            foreach (var octopus in octopuses)
                octopus.IncreaseEnergy();

            if (numberOfSimulataneousFlashes == octopuses.Count)
                return numberOfSteps;

            numberOfSteps++;
            numberOfSimulataneousFlashes = 0;

            foreach (var octopus in octopuses)
                octopus.PerformEndOfStep();
        }
    }
}
