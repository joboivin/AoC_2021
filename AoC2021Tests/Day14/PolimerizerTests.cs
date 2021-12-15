using System.Collections.Generic;
using System.Threading.Tasks;
using AoC2021.Day14;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day14;

public class PolimerizerTests
{
    private readonly IPolymerProvider _polymerProvider;

    private readonly Polymerizer _subject;

    public PolimerizerTests()
    {
        _polymerProvider = Substitute.For<IPolymerProvider>();

        _subject = new Polymerizer(_polymerProvider);
    }

    [Theory]
    [InlineData(1, "NCNBCHB")]
    [InlineData(2, "NBCCNBBBCBHCB")]
    [InlineData(3, "NBBBCNCCNBBNBNBBCHBHHBCHB")]
    public async Task PolimerizeAsync_WhenUsingAoCInput_ThenReturnsExpectedPolymer(int numberOfStep, string expectedPolymer)
    {
        SetupPolymerProvider();

        var result = await _subject.PolimerizeAsync(numberOfStep);

        result.Should().Be(expectedPolymer);
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
