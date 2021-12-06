namespace AoC2021;

internal interface IDaySolver
{
    Task<long> SolveProblemAsync();
    Task<long> SolveBonusProblemAsync();
}

