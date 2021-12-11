using AoC2021.Common;
using AoC2021.Day11;

namespace AoC2021;

internal class Program
{
    public static Task Main(string[] args)
    {
        //return SolveProblemAsync(new Day1Solver(new RawInputProvider(@"Day1\Input.txt"), new MesurementsCleaner()), 1);
        //return SolveProblemAsync(new Day2Solver(new RawInputProvider(@"Day2\Input.txt"), new PositionCalculator()), 2);
        //return SolveProblemAsync(new Day3Solver(new RatesCalculator(new RawInputProvider(@"Day3\Input.txt"))), 3);
        //return SolveProblemAsync(new Day4Solver(new BingoCreator(new RawInputProvider(@"Day4\Input.txt"))), 4);
        //return SolveProblemAsync(new Day5Solver(new RawInputProvider(@"Day5\Input.txt"), new HydrothermalVentPointsProvider()), 5);
        //return SolveProblemAsync(new Day6Solver(new LanternfishSwarmPopulationCalculator(new RawInputProvider(@"day6\Input.txt"), new LanternfishReproductionCalculator())), 6);
        //return SolveProblemAsync(new Day7Solver(new RawInputProvider(@"Day7\Input.txt")), 7);
        //return SolveProblemAsync(new Day8Solver(new RawInputProvider(@"Day8\Input.txt"), new DigitValuesFinder()), 8);
        //return SolveProblemAsync(new Day9Solver(new HeightmapProvider(new RawInputProvider(@"Day9\Input.txt"))), 9);
        //return SolveProblemAsync(new Day10Solver(new RawInputProvider(@"Day10\Input.txt"), new LineAnalyser()), 10);
        return SolveProblemAsync(new Day11Solver(new OctopusSimulator(new OctopusGridProvider(new RawInputProvider(@"Day11\Input.txt")))), 11);
    }

    public static async Task SolveProblemAsync(IDaySolver daySolver, int day)
    {
        var solution = daySolver.SolveProblemAsync();
        var bonusSolution = daySolver.SolveBonusProblemAsync();

        Console.WriteLine($"Solution for Day {day} is {await solution}");
        Console.WriteLine($"Bonus solution for Day {day} is {await bonusSolution}");
    }
}

