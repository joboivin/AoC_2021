using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day11;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day11;

public class OctopusSimulatorTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly OctopusSimulator _subject;

    public OctopusSimulatorTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new OctopusSimulator(new OctopusGridProvider(_rawInputProvider));
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SimulateOctopusesAsync_WhenUsingAoCInputAnd10Steps_ThenReturnsAoCResult()
    {
        SetupRawInputProvider();

        var result = await _subject.SimulateOctopusesAsync(10);

        result.Should().Be(204);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SimulateOctopusesAsync_WhenUsingAoCInputAnd100Steps_ThenReturnsAoCResult()
    {
        SetupRawInputProvider();

        var result = await _subject.SimulateOctopusesAsync(100);

        result.Should().Be(1656);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SimulateOctopusesComplexlyAsync_WhenUsingAoCInputAnd100Steps_ThenReturnsAoCResult()
    {
        SetupRawInputProvider();

        var result = await _subject.SimulateOctopusesComplexlyAsync();

        result.Should().Be(195);
    }

    private void SetupRawInputProvider()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        }.ToAsyncEnumerable());
    }
}

