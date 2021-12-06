using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day5;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day5;

public class Day5SolverTests
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly IHydrothermalVentPointsProvider _hydrothermalVentPointsProvider;

    private readonly Day5Solver _subject;

    public Day5SolverTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();
        _hydrothermalVentPointsProvider = Substitute.For<IHydrothermalVentPointsProvider>();

        _subject = new Day5Solver(_rawInputProvider, _hydrothermalVentPointsProvider);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenNoVentOverlaps_ThenReturns0()
    {
        const string line1 = "line1";
        const string line2 = "line2";
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { line1, line2 }.ToAsyncEnumerable());
        _hydrothermalVentPointsProvider.ProvidePoints(line1).Returns(new[] { (0, 1), (0, 2), (0, 3) });
        _hydrothermalVentPointsProvider.ProvidePoints(line2).Returns(new[] { (0, 4), (0, 5), (0, 6) });

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(0);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenVentsOverlap_ThenReturnsNumberOdOverlaps()
    {
        const string line1 = "line1";
        const string line2 = "line2";
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { line1, line2 }.ToAsyncEnumerable());
        _hydrothermalVentPointsProvider.ProvidePoints(line1).Returns(new[] { (0, 1), (0, 2), (0, 3) });
        _hydrothermalVentPointsProvider.ProvidePoints(line2).Returns(new[] { (0, 2), (0, 3), (0, 4) });

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(2);
    }

    [Fact]
    public async Task SolveBonusProblemAsync_WhenNoVentOverlaps_ThenReturns0()
    {
        const string line1 = "line1";
        const string line2 = "line2";
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { line1, line2 }.ToAsyncEnumerable());
        _hydrothermalVentPointsProvider.ProvideAllPoints(line1).Returns(new[] { (0, 1), (0, 2), (0, 3) });
        _hydrothermalVentPointsProvider.ProvideAllPoints(line2).Returns(new[] { (0, 4), (0, 5), (0, 6) });

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(0);
    }

    [Fact]
    public async Task SolveBonusProblemAsync_WhenVentsOverlap_ThenReturnsNumberOdOverlaps()
    {
        const string line1 = "line1";
        const string line2 = "line2";
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { line1, line2 }.ToAsyncEnumerable());
        _hydrothermalVentPointsProvider.ProvideAllPoints(line1).Returns(new[] { (0, 1), (0, 2), (0, 3) });
        _hydrothermalVentPointsProvider.ProvideAllPoints(line2).Returns(new[] { (0, 2), (0, 3), (0, 4) });

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(2);
    }
}
