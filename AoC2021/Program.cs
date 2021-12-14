using AoC2021.Common;
using AoC2021.Day13;

namespace AoC2021;

internal class Program
{
    public static Task Main(string[] args)
    {
        return SolveProblemAsync(new Day13Solver(new PaperProvider(new RawInputProvider(@"Day13\Input.txt")), new Day13.Console()), 13);
    }

    public static async Task SolveProblemAsync(IDaySolver daySolver, int day)
    {
        var solution = await daySolver.SolveProblemAsync();
        var bonusSolution = daySolver.SolveBonusProblemAsync();

        System.Console.WriteLine($"Solution for Day {day} is {solution}");
        System.Console.WriteLine($"Bonus solution for Day {day} is {await bonusSolution}");
    }
}

