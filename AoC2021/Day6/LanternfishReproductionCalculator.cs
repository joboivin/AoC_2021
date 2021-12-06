namespace AoC2021.Day6;

internal class LanternfishReproductionCalculator : ILanternfishReproductionCalculator
{
    const int LanternfishReproductionRate = 6;
    const int NewbornLanternfishReproductionRate = LanternfishReproductionRate + 2;

    public long CalculateReproduction(int internalTimer, int numberOfDays)
    {
        var populationByInternalTimer = InitializePopulationByInternalTimer(internalTimer);

        for (var i = 0; i < numberOfDays; i++)
        {
            var numberOfFishesWhoJustGaveBirth = populationByInternalTimer[0];
            populationByInternalTimer[0] = 0;

            for (var j = 1; j <= NewbornLanternfishReproductionRate; j++)
            {
                populationByInternalTimer[j - 1] = populationByInternalTimer[j];
                populationByInternalTimer[j] = 0;
            }

            populationByInternalTimer[LanternfishReproductionRate] += numberOfFishesWhoJustGaveBirth;
            populationByInternalTimer[NewbornLanternfishReproductionRate] = numberOfFishesWhoJustGaveBirth;
        }

        return populationByInternalTimer.Values.Sum();
    }

    private Dictionary<int, long> InitializePopulationByInternalTimer(int internalTimer)
    {
        var initialPopulationByInternalTimer = new Dictionary<int, long>();

        for (var i = 0; i <= NewbornLanternfishReproductionRate; i++)
            initialPopulationByInternalTimer.Add(i, i == internalTimer ? 1 : 0);

        return initialPopulationByInternalTimer;
    }
}
