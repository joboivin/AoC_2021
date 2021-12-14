using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day13;
using FluentAssertions;
using FluentAssertions.Execution;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day13;

public class PaperProviderTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly PaperProvider _subject;

    public PaperProviderTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new PaperProvider(_rawInputProvider);
    }

    [Fact]
    public async Task ProvidePaperAsync_ThenReturnsExpectedPaper()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "1,2", "3,4", "0,0", "10,11", "", "line1", "line2" }.ToAsyncEnumerable());

        var (result, _) = await _subject.ProvidePaperAsync();

        using (new AssertionScope())
        {
            result.GetUpperBound(0).Should().Be(10);
            result.GetUpperBound(1).Should().Be(11);
            result[0, 0].Should().BeTrue();
            result[1, 0].Should().BeFalse();
            result[0, 1].Should().BeFalse();
        }
    }

    [Fact]
    public async Task ProvidePaperAsync_ThenReturnsExpectedFoldInstructions()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "1,2", "3,4", "0,0", "10,11", "", "line1", "line2" }.ToAsyncEnumerable());

        var (_, result) = await _subject.ProvidePaperAsync();

        using (new AssertionScope())
        {
            result.Should().HaveCount(2);
            result.Should().Contain("line1");
            result.Should().Contain("line2");
        }
    }
}
