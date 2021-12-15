using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day14;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day14;

public class PolymerProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly PolymerProvider _subject;

    public PolymerProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new PolymerProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvidePolymerAsync_ThenFirstLineIsPolymerTemplate()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "ABC", "", "AB -> D" }.ToAsyncEnumerable());

        var (result, _) = await _subject.ProvidePolymerAsync();

        result.Should().Be("ABC");
    }

    [Fact]
    public async Task ProvidePolymerAsync_WhenInputContains1Instruction_ThenReturns1Instruction()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "ABC", "", "AB -> D" }.ToAsyncEnumerable());

        var (_, result) = await _subject.ProvidePolymerAsync();

        result.Should().HaveCount(1);
        result.Should().ContainKey("AB").WhichValue.Should().Be("D");
    }

    [Fact]
    public async Task ProvidePolymerAsync_WhenInputContains2Instructions_ThenReturns2Instructions()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "ABC", "", "AB -> D", "BC -> E" }.ToAsyncEnumerable());

        var (_, result) = await _subject.ProvidePolymerAsync();

        result.Should().HaveCount(2);
        result.Should().ContainKey("AB").WhichValue.Should().Be("D");
        result.Should().ContainKey("BC").WhichValue.Should().Be("E");
    }
}
