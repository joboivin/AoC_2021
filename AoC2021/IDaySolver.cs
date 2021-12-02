namespace AoC2021;

internal interface IDaySolver
{
    Task<int> SolveProblemAsync();
    Task<int> SolveBonusProblemAsync();
}

