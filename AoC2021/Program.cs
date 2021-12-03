using AoC2021.Common;
using AoC2021.Day1;

namespace AoC2021;

internal class Program
{
    public static Task Main(string[] args)
    {
        return SolveProblem(new Day1Solver(new RawInputProvider(@"Day1\Input.txt"), new MesurementsCleaner()), 1);
    }

    public static async Task SolveProblem(IDaySolver daySolver, int day)
    {
        var solution = daySolver.SolveProblemAsync();
        var bonusSolution = daySolver.SolveBonusProblemAsync();

        Console.WriteLine($"Solution for Day {day} is {await solution}");
        Console.WriteLine($"Bonus solution for Day {day} is {await bonusSolution}");
    }
}

