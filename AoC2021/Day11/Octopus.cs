namespace AoC2021.Day11;

internal class Octopus
{
    public const int FlashEnergyLevel = 9;

    private readonly Action _flash;
    private readonly IList<Octopus> _adjacentOctopuses;

    public Octopus(int initialEnergy, Action flash)
    {
        Energy = initialEnergy;
        _flash = flash;
        _adjacentOctopuses = new List<Octopus>();
    }

    public int Energy { get; private set; }
    public IEnumerable<Octopus> AdjacentOctopuses => _adjacentOctopuses;

    public void IncreaseEnergy()
    {
        Energy++;

        if (Energy == FlashEnergyLevel + 1)
        {
            _flash();

            foreach (var adjacentOctopus in _adjacentOctopuses)
                adjacentOctopus.IncreaseEnergy();
        }
    }

    public void AddAdjacentOctopus(Octopus adjacent)
    {
        _adjacentOctopuses.Add(adjacent);
    }

    public void PerformEndOfStep()
    {
        if (Energy > FlashEnergyLevel)
            Energy = 0;
    }
}
