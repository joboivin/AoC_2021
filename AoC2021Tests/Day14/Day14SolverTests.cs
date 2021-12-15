using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day14;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day14;

public class Day14SolverTests
{
    private readonly IPolymerizer _polymeriser;

    private readonly Day14Solver _subject;

    public Day14SolverTests()
    {
        _polymeriser = Substitute.For<IPolymerizer>();

        _subject = new Day14Solver(_polymeriser);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenUsingBasicExample_ThenReturnsExpectedResult()
    {
        _polymeriser.PolimerizeAsync(10).Returns("ABBCCCDDDDEEEEE");

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(4);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenUsingMoreAdvancedExample_ThenReturnsExpectedResult()
    {
        _polymeriser.PolimerizeAsync(10).Returns("ABCDEBCDECDEDEE");

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(4);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        var subject = CreateFunctionalSubject();

        var result = await subject.SolveProblemAsync();

        result.Should().Be(1588);
    }

    private Day14Solver CreateFunctionalSubject()
    {
        var rawInputProvider = Substitute.For<IRawInputProvider>();
        rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C"
        }.ToAsyncEnumerable());

        return new Day14Solver(new Polymerizer(new PolymerProvider(rawInputProvider)));
    }
}
