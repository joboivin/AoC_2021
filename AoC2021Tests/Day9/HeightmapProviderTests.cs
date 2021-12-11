using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day9;
using FluentAssertions;
using FluentAssertions.Execution;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day9;

public class HeightmapProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly HeightmapProvider _subject;

    public HeightmapProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new HeightmapProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvideHeightMapAsync_ThenReturnsHeightMap()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "2199943210", "3987894921", "9856789892", "8767896789", "9899965678"
        }.ToAsyncEnumerable());

        var result = await _subject.ProvideHeightMapAsync();

        using (new AssertionScope())
        {
            result.Should().HaveCount(5);
            result[0].Should().HaveCount(10);
            result[0][0].Should().Be(2);
            result[1][1].Should().Be(9);
            result[4][8].Should().Be(7);
        }
    }
}
