using System;
using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day3;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day3;

public class RatesCalculatorTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly RatesCalculator _subject;

    public RatesCalculatorTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new RatesCalculator(_rawInputProvider);
    }

    [Theory]
    [InlineData(2, "01", "10", "00")]
    [InlineData(3, "000", "111", "101", "101")]
    public async Task CalculatePowerConsumptionRatesAsync_WhenInputLinesHaveXChars_ThenRatesHaveXChars(int lineLength, params string[] lines)
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(lines.ToAsyncEnumerable());

        var result = await _subject.CalculatePowerConsumptionRatesAsync();

        result.gamma.Length.Should().Be(lineLength);
        result.epsilon.Length.Should().Be(lineLength);
    }

    [Fact]
    public async Task CalculatePowerConsumptionRatesAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] {"00100", "11110", "10110", "10111", "10101", "01111",
            "00111", "11100", "10000", "11001", "00010", "01010"}.ToAsyncEnumerable());

        var result = await _subject.CalculatePowerConsumptionRatesAsync();

        result.gamma.Should().BeEquivalentTo("10110");
        result.epsilon.Should().BeEquivalentTo("01001");
    }

    [Fact]
    public void CalculatePowerConsumptionRatesAsync_WhenSameNumberOF0And1In1Position_ThenException()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "0000", "1111", "0000", "1110" }.ToAsyncEnumerable());

        var action = () => _subject.CalculatePowerConsumptionRatesAsync();

        action.Should().Throw<Exception>();
    }

    [Fact]
    public async Task CalculateLifeSupportRatesAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] {"00100", "11110", "10110", "10111", "10101", "01111",
            "00111", "11100", "10000", "11001", "00010", "01010"}.ToAsyncEnumerable());

        var result = await _subject.CalculateLifeSupportRatesAsync();

        result.oxygen.Should().BeEquivalentTo("10111");
        result.co2.Should().BeEquivalentTo("01010");
    }
}
