using System.Collections.Generic;
using System.Threading.Tasks;
using AoC2021.Day9;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day9;

public class Day9SolverTests
{
    private readonly IHeightmapProvider _heightmapProvider;

    private readonly Day9Solver _subject;

    public Day9SolverTests()
    {
        _heightmapProvider = Substitute.For<IHeightmapProvider>();

        _subject = new Day9Solver(_heightmapProvider);
    }

    [Theory]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    [InlineData(4, 0)]
    public async Task SolveProblemAsync_WhenLowPointIsBelowOtherPoint_ThenLowPointIsFound(int potentialLowPoint, int expectedSum)
    {
        _heightmapProvider.ProvideHeightMapAsync().Returns(new List<List<int>> { new List<int> { 4 }, new List<int> { potentialLowPoint } });

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(expectedSum);
    }

    [Theory]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    [InlineData(4, 0)]
    public async Task SolveProblemAsync_WhenLowPointIsAboveOtherPoint_ThenLowPointIsFound(int potentialLowPoint, int expectedSum)
    {
        _heightmapProvider.ProvideHeightMapAsync().Returns(new List<List<int>> { new List<int> { potentialLowPoint }, new List<int> { 4 } });

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(expectedSum);
    }

    [Theory]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    [InlineData(4, 0)]
    public async Task SolveProblemAsync_WhenLowPointIsRightToOtherPoint_ThenLowPointIsFound(int potentialLowPoint, int expectedSum)
    {
        _heightmapProvider.ProvideHeightMapAsync().Returns(new List<List<int>> { new List<int> { 4, potentialLowPoint } });

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(expectedSum);
    }

    [Theory]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    [InlineData(4, 0)]
    public async Task SolveProblemAsync_WhenLowPointIsLeftToOtherPoint_ThenLowPointIsFound(int potentialLowPoint, int expectedSum)
    {
        _heightmapProvider.ProvideHeightMapAsync().Returns(new List<List<int>> { new List<int> { potentialLowPoint, 4 } });

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(expectedSum);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        _heightmapProvider.ProvideHeightMapAsync().Returns(new List<List<int>>
        {
            new List<int> { 2, 1, 9, 9, 9, 4, 3, 2, 1, 0 },
            new List<int> { 3, 9, 8, 7, 8, 9, 4, 9, 2, 1 },
            new List<int> { 9, 8, 5, 6, 7, 8, 9, 8, 9, 2 },
            new List<int> { 8, 7, 6, 7, 8, 9, 6, 7, 8, 9 },
            new List<int> { 9, 8, 9, 9, 9, 6, 5, 6, 7, 8 }
        });

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(15);
    }

    [Fact]
    public async Task SolveBonusProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        _heightmapProvider.ProvideHeightMapAsync().Returns(new List<List<int>>
        {
            new List<int> { 2, 1, 9, 9, 9, 4, 3, 2, 1, 0 },
            new List<int> { 3, 9, 8, 7, 8, 9, 4, 9, 2, 1 },
            new List<int> { 9, 8, 5, 6, 7, 8, 9, 8, 9, 2 },
            new List<int> { 8, 7, 6, 7, 8, 9, 6, 7, 8, 9 },
            new List<int> { 9, 8, 9, 9, 9, 6, 5, 6, 7, 8 }
        });

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(1134);
    }
}
