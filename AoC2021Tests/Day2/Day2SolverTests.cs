using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day2;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day2;

public class Day2SolverTests
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly IPositionCalculator _positionCalculator;

    private readonly Day2Solver _subject;

    public Day2SolverTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();
        _positionCalculator = Substitute.For<IPositionCalculator>();

        _subject = new Day2Solver(_rawInputProvider, _positionCalculator);
    }

    [Fact]
    public async Task SolveProblemAsync_ThenReturnsHorizontalMultipliedByVertical()
    {
        var input = new[] { "" }.ToAsyncEnumerable();
        _rawInputProvider.ProvideRawInputAsync().Returns(input);
        _positionCalculator.CalculateBasicPositionAsync(input).Returns((10, 20));

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(200);
    }

    [Fact]
    public async Task SolveBonusProblemAsync_ThenReturnsHorizontalMultipliedByVertical()
    {
        var input = new[] { "" }.ToAsyncEnumerable();
        _rawInputProvider.ProvideRawInputAsync().Returns(input);
        _positionCalculator.CalculateAdvancedPositionAsync(input).Returns((10, 20));

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(200);
    }
}
