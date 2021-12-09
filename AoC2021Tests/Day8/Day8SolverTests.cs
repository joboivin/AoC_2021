using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day8;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day8;

public class Day8SolverTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly Day8Solver _subject;

    public Day8SolverTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new Day8Solver(_rawInputProvider, new DigitValuesFinder());
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        SetupRawInputProvider();

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(26);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveBonusProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        SetupRawInputProvider();

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(61229);
    }

    private void SetupRawInputProvider()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        }.ToAsyncEnumerable());
    }
}
