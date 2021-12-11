using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day11;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day11;

public class OctopusGridProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly OctopusGridProvider _subject;

    public OctopusGridProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new OctopusGridProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvideOctopusesAsync_WhenInputContains10LinesWith10OctopusesPerLine_ThenReturns100Octopuses()
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

        var result = await _subject.ProvideOctopusesAsync(() => { });

        result.Should().HaveCount(100);
        result.Where(o => o.Energy == 7).Should().HaveCount(9);
    }

    [Fact]
    public async Task ProvideOctopusesAsync_WhenOctopusIsInTheMiddle_ThenAdjacentOctopusesAreSetCorrectly()
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

        var result = await _subject.ProvideOctopusesAsync(() => { });

        var firstOctopusWith7Energy = result.First(o => o.Energy == 7);
        firstOctopusWith7Energy.AdjacentOctopuses.Should().HaveCount(8);
        var adjacentOctopusesEnergy = firstOctopusWith7Energy.AdjacentOctopuses.Select(o => o.Energy);
        adjacentOctopusesEnergy.Should().BeEquivalentTo(new[] { 5, 4, 8, 2, 4, 5, 2, 6 });
    }

    [Fact]
    public async Task ProvideOctopusesAsync_WhenOctopusIsInTop_ThenAdjacentOctopusesAreSetCorrectly()
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

        var result = await _subject.ProvideOctopusesAsync(() => { });

        var firstOctopusWith4Energy = result.First(o => o.Energy == 4);
        firstOctopusWith4Energy.AdjacentOctopuses.Should().HaveCount(5);
        var adjacentOctopusesEnergy = firstOctopusWith4Energy.AdjacentOctopuses.Select(o => o.Energy);
        adjacentOctopusesEnergy.Should().BeEquivalentTo(new[] { 5, 8, 2, 7, 4 });
    }

    [Fact]
    public async Task ProvideOctopusesAsync_WhenOctopusIsInBottomLeft_ThenAdjacentOctopusesAreSetCorrectly()
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

        var result = await _subject.ProvideOctopusesAsync(() => { });

        var thirtheentOctopusWith5Energy = result.Where(o => o.Energy == 5).Skip(12).First();
        thirtheentOctopusWith5Energy.AdjacentOctopuses.Should().HaveCount(3);
        var adjacentOctopusesEnergy = thirtheentOctopusWith5Energy.AdjacentOctopuses.Select(o => o.Energy);
        adjacentOctopusesEnergy.Should().BeEquivalentTo(new[] { 4, 8, 2 });
    }

    [Fact]
    public async Task ProvideOctopusesAsync_WhenOctopusIsInBottomRight_ThenAdjacentOctopusesAreSetCorrectly()
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

        var result = await _subject.ProvideOctopusesAsync(() => { });

        var lastOctopus = result.Last();
        lastOctopus.AdjacentOctopuses.Should().HaveCount(3);
        var adjacentOctopusesEnergy = lastOctopus.AdjacentOctopuses.Select(o => o.Energy);
        adjacentOctopusesEnergy.Should().BeEquivalentTo(new[] { 5, 4, 2 });
    }
}
