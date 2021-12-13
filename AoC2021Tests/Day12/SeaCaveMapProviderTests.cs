using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day12;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day12;

public class SeaCaveMapProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly SeaCaveMapProvider _subject;

    public SeaCaveMapProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new SeaCaveMapProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvideMapAsync_WhenInputContains1Line_ThenReturns2Caves()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "a-b" }.ToAsyncEnumerable());

        var result = await _subject.ProvideMapAsync();

        result.Should().HaveCount(2);
        result.Should().ContainKey("a");
        result.Should().ContainKey("b");
    }

    [Fact]
    public async Task ProvideMapAsync_WhenInputContains1Line_ThenCavesAreConnected()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "a-b" }.ToAsyncEnumerable());

        var result = await _subject.ProvideMapAsync();

        result["a"].ConnectedCaves.Should().ContainSingle().Which.Name.Should().Be("b");
        result["b"].ConnectedCaves.Should().ContainSingle().Which.Name.Should().Be("a");
    }

    [Fact]
    public async Task ProvideMapAsync_WhenInputContains2LinesWiht4DifferentCaves_ThenReturns4Caves()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "a-b", "c-d" }.ToAsyncEnumerable());

        var result = await _subject.ProvideMapAsync();

        result.Should().HaveCount(4);
        result.Should().ContainKey("a");
        result.Should().ContainKey("b");
        result.Should().ContainKey("c");
        result.Should().ContainKey("d");
    }

    [Fact]
    public async Task ProvideMapAsync_WhenInputContains2LinesWith4DifferentCaves_ThenCavesAreConnected()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "a-b", "c-d" }.ToAsyncEnumerable());

        var result = await _subject.ProvideMapAsync();

        result["a"].ConnectedCaves.Should().ContainSingle().Which.Name.Should().Be("b");
        result["b"].ConnectedCaves.Should().ContainSingle().Which.Name.Should().Be("a");
        result["c"].ConnectedCaves.Should().ContainSingle().Which.Name.Should().Be("d");
        result["d"].ConnectedCaves.Should().ContainSingle().Which.Name.Should().Be("c");
    }

    [Fact]
    public async Task ProvideMapAsync_WhenInputContains2LinesWihtSameCaveTwice_ThenReturns3Caves()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "a-b", "c-b" }.ToAsyncEnumerable());

        var result = await _subject.ProvideMapAsync();

        result.Should().HaveCount(3);
        result.Should().ContainKey("a");
        result.Should().ContainKey("b");
        result.Should().ContainKey("c");
    }

    [Fact]
    public async Task ProvideMapAsync_WhenInputContains2LinesWithSameCaveTwice_ThenCavesAreConnected()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "a-b", "c-b" }.ToAsyncEnumerable());

        var result = await _subject.ProvideMapAsync();

        result["a"].ConnectedCaves.Should().ContainSingle().Which.Name.Should().Be("b");
        result["c"].ConnectedCaves.Should().ContainSingle().Which.Name.Should().Be("b");
        result["b"].ConnectedCaves.Should().HaveCount(2);
        result["b"].ConnectedCaves.Should().Contain(c => c.Name == "a");
        result["b"].ConnectedCaves.Should().Contain(c => c.Name == "c");
    }
}
