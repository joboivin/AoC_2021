using AoC2021.Common;
using AoC2021.Day12;

namespace AoC2021;

internal class Program
{
    public static Task Main(string[] args)
    {
        return SolveProblemAsync(new Day12Solver(new SeaCaveMapProvider(new RawInputProvider(@"Day12\Input.txt"))), 12);
    }

    public static async Task SolveProblemAsync(IDaySolver daySolver, int day)
    {
        var solution = daySolver.SolveProblemAsync();
        var bonusSolution = daySolver.SolveBonusProblemAsync();

        Console.WriteLine($"Solution for Day {day} is {await solution}");
        Console.WriteLine($"Bonus solution for Day {day} is {await bonusSolution}");
    }
}

