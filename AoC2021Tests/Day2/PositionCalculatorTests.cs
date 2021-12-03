using System;
using System.Linq;
using System.Threading.Tasks;
using AoC2021.Day2;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day2;

public class PositionCalculatorTests
{
    private readonly PositionCalculator _subject;

    public PositionCalculatorTests()
    {
        _subject = new PositionCalculator();
    }

    [Fact]
    public async Task CalculateBasicPositionAsync_When1ForwardCommandOnly_ThenPositionIsCorrect()
    {
        var result = await _subject.CalculateBasicPositionAsync(new[] { "forward 12" }.ToAsyncEnumerable());

        result.horizontal.Should().Be(12);
        result.vertical.Should().Be(0);
    }

    [Fact]
    public async Task CalculateBasicPositionAsync_When2ForwardCommandsOnly_ThenPositionIsCorrect()
    {
        var result = await _subject.CalculateBasicPositionAsync(new[] { "forward 12", "forward 10" }.ToAsyncEnumerable());

        result.horizontal.Should().Be(22);
        result.vertical.Should().Be(0);
    }

    [Fact]
    public async Task CalculateBasicPositionAsync_When1UpCommandOnly_ThenPositionIsCorrect()
    {
        var result = await _subject.CalculateBasicPositionAsync(new[] { "up 12" }.ToAsyncEnumerable());

        result.horizontal.Should().Be(0);
        result.vertical.Should().Be(-12);
    }

    [Fact]
    public async Task CalculateBasicPositionAsync_When2UpCommandsOnly_ThenPositionIsCorrect()
    {
        var result = await _subject.CalculateBasicPositionAsync(new[] { "up 12", "up 10" }.ToAsyncEnumerable());

        result.horizontal.Should().Be(0);
        result.vertical.Should().Be(-22);
    }

    [Fact]
    public async Task CalculateBasicPositionAsync_When1DownCommandOnly_ThenPositionIsCorrect()
    {
        var result = await _subject.CalculateBasicPositionAsync(new[] { "down 12" }.ToAsyncEnumerable());

        result.horizontal.Should().Be(0);
        result.vertical.Should().Be(12);
    }

    [Fact]
    public async Task CalculateBasicPositionAsync_When2DownCommandsOnly_ThenPositionIsCorrect()
    {
        var result = await _subject.CalculateBasicPositionAsync(new[] { "down 12", "down 10" }.ToAsyncEnumerable());

        result.horizontal.Should().Be(0);
        result.vertical.Should().Be(22);
    }

    [Fact]
    public async Task CalculateBasicPositionAsync_WhenMixOfValidCommands_ThenPositionIsCorrect()
    {
        var result = await _subject.CalculateBasicPositionAsync(new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" }.ToAsyncEnumerable());

        result.horizontal.Should().Be(15);
        result.vertical.Should().Be(10);
    }

    [Fact]
    public async Task CalculateAdvancedPositionAsync_WhenMixOfValidCommands_ThenPositionIsCorrect()
    {
        var result = await _subject.CalculateAdvancedPositionAsync(new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" }.ToAsyncEnumerable());

        result.horizontal.Should().Be(15);
        result.vertical.Should().Be(60);
    }

    [Fact]
    public void CalculateBasicPositionAsync_WhenInvalidCommandIsPassed_ThenException()
    {
        var action = () => _subject.CalculateBasicPositionAsync(new[] { "forward 5", "down 5", "backward 8", "up 3", "down 8", "forward 2" }.ToAsyncEnumerable());

        action.Should().Throw<Exception>();
    }
}
