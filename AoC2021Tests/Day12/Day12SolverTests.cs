using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day12;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day12;

public class Day12SolverTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly Day12Solver _subject;

    public Day12SolverTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new Day12Solver(new SeaCaveMapProvider(_rawInputProvider));
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveProblemAsync_WhenUsingFirstAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "start-A", "start-b", "A-c", "A-b",
            "b-d", "A-end", "b-end"}.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(10);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveProblemAsync_WhenUsingSecondAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "dc-end", "HN-start", "start-kj", "dc-start",
            "dc-HN", "LN-dc", "HN-end", "kj-sa", "kj-HN", "kj-dc"}.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(19);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveProblemAsync_WhenUsingThirdAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "fs-end", "he-DX", "fs-he", "start-DX", "pj-DX",
            "end-zg", "zg-sl", "zg-pj", "pj-he", "RW-he", "fs-DX", "pj-RW", "zg-RW", "start-pj", "he-WI",
            "zg-he", "pj-fs", "start-RW"}.ToAsyncEnumerable());

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(226);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveBonusProblemAsync_WhenUsingFirstAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "start-A", "start-b", "A-c", "A-b",
            "b-d", "A-end", "b-end"}.ToAsyncEnumerable());

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(36);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveBonusProblemAsync_WhenUsingSecondAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "dc-end", "HN-start", "start-kj", "dc-start",
            "dc-HN", "LN-dc", "HN-end", "kj-sa", "kj-HN", "kj-dc"}.ToAsyncEnumerable());

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(103);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveBonusProblemAsync_WhenUsingThirdAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "fs-end", "he-DX", "fs-he", "start-DX", "pj-DX",
            "end-zg", "zg-sl", "zg-pj", "pj-he", "RW-he", "fs-DX", "pj-RW", "zg-RW", "start-pj", "he-WI",
            "zg-he", "pj-fs", "start-RW"}.ToAsyncEnumerable());

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(3509);
    }
}
