using System.Collections.Generic;
using System.Threading.Tasks;
using AoC2021.Day14;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day14;

public class SimplePolimerizerTests
{
    private readonly IPolymerProvider _polymerProvider;

    private readonly SimplePolymerizer _subject;

    public SimplePolimerizerTests()
    {
        _polymerProvider = Substitute.For<IPolymerProvider>();

        _subject = new SimplePolymerizer(_polymerProvider);
    }

    [Fact]
    public async Task PolymerizeAsync_WhenUsingAoCInputAnd10Steps_ThenReturnsAoCResult()
    {
        SetupPolymerProvider();

        var result = await _subject.PolymerizeAsync(10);

        result.Should().Be(1588);
    }

    [Fact]
    public async Task PolymerizeAsync_WhenUsingAoCInputAnd40Steps_ThenReturnsAoCResultWithoutTakingTwoMuchTimeAndMemory()
    {
        SetupPolymerProvider();

        var result = await _subject.PolymerizeAsync(40);

        result.Should().Be(2188189693529);
    }

    private void SetupPolymerProvider()
    {
        _polymerProvider.ProvidePolymerAsync().Returns(("NNCB", new Dictionary<string, string>
        {
            {"CH", "B" },
            {"HH", "N" },
            {"CB", "H" },
            {"NH", "C" },
            {"HB", "C" },
            {"HC", "B" },
            {"HN", "C" },
            {"NN", "C" },
            {"BH", "H" },
            {"NC", "B" },
            {"NB", "B" },
            {"BN", "B" },
            {"BB", "N" },
            {"BC", "B" },
            {"CC", "N" },
            {"CN", "C" }
        }));
    }
}
