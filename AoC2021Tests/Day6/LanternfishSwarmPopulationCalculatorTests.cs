using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day6;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day6;

public class LanternfishSwarmPopulationCalculatorTests
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly ILanternfishReproductionCalculator _lanternfishReproductionCalculator;

    private readonly LanternfishSwarmPopulationCalculator _subject;

    public LanternfishSwarmPopulationCalculatorTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();
        _lanternfishReproductionCalculator = Substitute.For<ILanternfishReproductionCalculator>();

        _subject = new LanternfishSwarmPopulationCalculator(_rawInputProvider, _lanternfishReproductionCalculator);
    }

    [Fact]
    public async Task CalculatePopulationAsync_When1Fish_ThenReturnsPopulationForThisFish()
    {
        const int numberOfDays = 10;
        const int lanternfishReproduction = 25;

        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "3" }.ToAsyncEnumerable());
        _lanternfishReproductionCalculator.CalculateReproduction(3, numberOfDays).Returns(lanternfishReproduction);

        var result = await _subject.CalculatePopulationAsync(numberOfDays);

        result.Should().Be(lanternfishReproduction);
    }

    [Fact]
    public async Task CalculatePopulationAsync_When2FishesWithSameTimer_ThenReturnsPopulationForThisTimerTwice()
    {
        const int numberOfDays = 10;
        const int lanternfishReproduction = 25;

        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "3,3" }.ToAsyncEnumerable());
        _lanternfishReproductionCalculator.CalculateReproduction(3, numberOfDays).Returns(lanternfishReproduction);

        var result = await _subject.CalculatePopulationAsync(numberOfDays);

        result.Should().Be(lanternfishReproduction * 2);
    }

    [Fact]
    public async Task CalculatePopulationAsync_When2FishesWithSameTimer_ThenCallsReproductionCalculatorOnce()
    {
        const int numberOfDays = 10;

        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "3,3" }.ToAsyncEnumerable());

        await _subject.CalculatePopulationAsync(numberOfDays);

        _lanternfishReproductionCalculator.Received(1).CalculateReproduction(3, numberOfDays);
    }

    [Fact]
    public async Task CalculatePopulationAsync_When2FishesWithDifferentTimers_ThenReturnsPopulationSum()
    {
        const int numberOfDays = 10;
        const int lanternfishReproduction1 = 25;
        const int lanternfishReproduction2 = 15;

        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "3,4" }.ToAsyncEnumerable());
        _lanternfishReproductionCalculator.CalculateReproduction(3, numberOfDays).Returns(lanternfishReproduction1);
        _lanternfishReproductionCalculator.CalculateReproduction(4, numberOfDays).Returns(lanternfishReproduction2);

        var result = await _subject.CalculatePopulationAsync(numberOfDays);

        result.Should().Be(lanternfishReproduction1 + lanternfishReproduction2);
    }

    [Theory, Trait("Category", "Functional")]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    [InlineData(256, 26984457539)]
    public async Task CalculatePopulationAsync_WhenUsingAoCInput_ThenReturnsAoCResult(int numberOfDays, long expectedPopulation)
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "3,4,3,1,2" }.ToAsyncEnumerable());
        var subject = new LanternfishSwarmPopulationCalculator(_rawInputProvider, new LanternfishReproductionCalculator());

        var result = await subject.CalculatePopulationAsync(numberOfDays);

        result.Should().Be(expectedPopulation);
    }
}

