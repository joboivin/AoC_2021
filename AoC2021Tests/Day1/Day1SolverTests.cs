using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day1;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day1;

public class Day1SolverTests
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly IMesurementsCleaner _mesurementsCleaner;

    private readonly Day1Solver _subject;

    public Day1SolverTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();
        _mesurementsCleaner = Substitute.For<IMesurementsCleaner>();

        _subject = new Day1Solver(_rawInputProvider, _mesurementsCleaner);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenOnly1Mesurement_ThenReturns0()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "100" }.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(0);
    }

    [Fact]
    public async Task SolveProblemAsync_When2MesurementsAndSecondMesurementIsLarger_ThenReturn1()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "100", "200" }.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(1);
    }

    [Fact]
    public async Task SolveProblemAsync_When2MesurementsAndSecondMesurementIsSmaller_ThenReturn0()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "100", "99" }.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(0);
    }

    [Fact]
    public async Task SolveProblemAsync_When3MesurementsAndSecondMesurementSmallerThanFirstAndThirdMesurementLargerThanSecondButSmallerThanFirst_ThenReturns1()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "100", "50", "75" }.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(1);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsExpectedResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" }.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(7);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveBonusProblemAsync_WhenUsingAoCInput_ThenReturnsExpectedResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "199", "200", "208", "210", "200", "207", "240", "269", "260", "263" }.ToAsyncEnumerable());
        var subject = new Day1Solver(_rawInputProvider, new MesurementsCleaner());

        var result = await subject.SolveBonusProblemAsync();

        result.Should().Be(5);
    }
}

