using System.Threading.Tasks;
using AoC2021.Day6;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day6;

public class Day6SolverTests
{
    private readonly ILanternfishSwarmPopulationCalculator _lanternfishSwarmPopulationCalculator;

    private readonly Day6Solver _subject;

    public Day6SolverTests()
    {
        _lanternfishSwarmPopulationCalculator = Substitute.For<ILanternfishSwarmPopulationCalculator>();

        _subject = new Day6Solver(_lanternfishSwarmPopulationCalculator);
    }

    [Fact]
    public async Task SolveProblemAsync_ThenReturnsPopulationCalculatedFor80Days()
    {
        const int expectedPopulation = 100;

        _lanternfishSwarmPopulationCalculator.CalculatePopulationAsync(80).Returns(expectedPopulation);

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(expectedPopulation);
    }

    [Fact]
    public async Task SolveBonusProblemAsync_ThenReturnsPopulationCalculatedFor256Days()
    {
        const int expectedPopulation = 100;

        _lanternfishSwarmPopulationCalculator.CalculatePopulationAsync(256).Returns(expectedPopulation);

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(expectedPopulation);
    }
}
