using AoC2021.Day6;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day6;

public class LanternfishReproductionCalculatorTests
{
    [Theory]
    [InlineData(3, 5, 2)]
    [InlineData(0, 10, 4)]
    [InlineData(1, 18, 7)]
    public void CalculateReproduction_WhenUsingSomeKnownInputs_ThenReturnsExpectedAnswer(int internalTimer, int numberOfDays, int expectedPopulation)
    {
        var subject = new LanternfishReproductionCalculator();

        var result = subject.CalculateReproduction(internalTimer, numberOfDays);

        result.Should().Be(expectedPopulation);
    }
}

