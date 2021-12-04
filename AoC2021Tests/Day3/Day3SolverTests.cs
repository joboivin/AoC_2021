using System.Threading.Tasks;
using AoC2021.Day3;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day3;

public class Day3SolverTests
{
    private readonly IRatesCalculator _ratesCalculator;

    private readonly Day3Solver _subject;

    public Day3SolverTests()
    {
        _ratesCalculator = Substitute.For<IRatesCalculator>();

        _subject = new Day3Solver(_ratesCalculator);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsExpectedResult()
    {
        _ratesCalculator.CalculatePowerConsumptionRatesAsync().Returns(("10110", "01001"));

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(198, "\"10110\" (22) * \"01001\" (9) is 198");
    }

    [Fact]
    public async Task SolveBonusProblemAsync_WhenUsingAoCInput_ThenReturnsExpectedResult()
    {
        _ratesCalculator.CalculateLifeSupportRatesAsync().Returns(("10111", "01010"));

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(230, "\"10111\" (23) * \"01010\" (10) is 230");
    }
}
