using AoC2021.Common;
using AoC2021.Day14;

namespace AoC2021;

internal class Program
{
    public static Task Main(string[] args)
    {
        var polymerProvider = new PolymerProvider(new RawInputProvider(@"Day14\Input.txt"));

        return SolveProblemAsync(new Day14Solver(new Polymerizer(polymerProvider), new SimplePolymerizer(polymerProvider)), 14);
    }

    public static async Task SolveProblemAsync(IDaySolver daySolver, int day)
    {
        var solution = daySolver.SolveProblemAsync();
        var bonusSolution = daySolver.SolveBonusProblemAsync();

        System.Console.WriteLine($"Solution for Day {day} is {await solution}");
        System.Console.WriteLine($"Bonus solution for Day {day} is {await bonusSolution}");
    }
}

