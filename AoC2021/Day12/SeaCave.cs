namespace AoC2021.Day12;

internal class SeaCave
{
    private readonly IList<SeaCave> _connectedCaves;

    public SeaCave(string name)
    {
        Name = name;
        _connectedCaves = new List<SeaCave>();
    }

    public string Name { get; private set; }

    public bool IsWorthVisitingMoreThanOnce =>
        Name.IsUpperCase();

    public IEnumerable<SeaCave> ConnectedCaves => _connectedCaves;

    public void AddConnectedCave(SeaCave connectedSeaCave)
    {
        _connectedCaves.Add(connectedSeaCave);
    }
}
