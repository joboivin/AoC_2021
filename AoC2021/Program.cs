using AoC2021.Common;
using AoC2021.Day7;

namespace AoC2021;

internal class Program
{
    public static Task Main(string[] args)
    {
        //return SolveProblem(new Day1Solver(new RawInputProvider(@"Day1\Input.txt"), new MesurementsCleaner()), 1);
        //return SolveProblem(new Day2Solver(new RawInputProvider(@"Day2\Input.txt"), new PositionCalculator()), 2);
        //return SolveProblem(new Day3Solver(new RatesCalculator(new RawInputProvider(@"Day3\Input.txt"))), 3);
        //return SolveProblem(new Day4Solver(new BingoCreator(new RawInputProvider(@"Day4\Input.txt"))), 4);
        //return SolveProblem(new Day5Solver(new RawInputProvider(@"Day5\Input.txt"), new HydrothermalVentPointsProvider()), 5);
        //return SolveProblem(new Day6Solver(new LanternfishSwarmPopulationCalculator(new RawInputProvider(@"day6\Input.txt"), new LanternfishReproductionCalculator())), 6);
        return SolveProblem(new Day7Solver(new RawInputProvider(@"Day7\Input.txt")), 7);
    }

    public static async Task SolveProblem(IDaySolver daySolver, int day)
    {
        var solution = daySolver.SolveProblemAsync();
        var bonusSolution = daySolver.SolveBonusProblemAsync();

        Console.WriteLine($"Solution for Day {day} is {await solution}");
        Console.WriteLine($"Bonus solution for Day {day} is {await bonusSolution}");
    }
}

