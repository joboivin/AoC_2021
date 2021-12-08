using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day7;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day7;

public class Day7SolverTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly Day7Solver _subject;

    public Day7SolverTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new Day7Solver(_rawInputProvider);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "16,1,2,0,4,2,7,1,2,14" }.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(37);
    }

    [Fact]
    public async Task SolveBonusProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "16,1,2,0,4,2,7,1,2,14" }.ToAsyncEnumerable());

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(168);
    }
}
