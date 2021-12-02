namespace AoC2021;

internal class Program
{
    public static async Task Main(string[] args)
    {
        //return SolbeProblem(new Day1Solver(), 1);
    }

    public static async Task SolveProblem(IDaySolver daySolver, int day)
    {
        var solution = daySolver.SolveProblemAsync();
        var bonusSolution = daySolver.SolveBonusProblemAsync();

        Console.WriteLine($"Solution for Day {day} is {await solution}");
        Console.WriteLine($"Bonus solution for Day {day} is {await bonusSolution}");
    }
}

