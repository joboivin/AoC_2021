using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day10;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day10;

public class Day10SolverTests
{
    private readonly IRawInputProvider _rawInputProvider;
    private readonly ILineAnalyser _lineAnalyser;

    private readonly Day10Solver _subject;

    public Day10SolverTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();
        _lineAnalyser = Substitute.For<ILineAnalyser>();

        _subject = new Day10Solver(_rawInputProvider, _lineAnalyser);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenInputContains1IllegalParanthese_ThenReturns3()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "line1", "line2", "line3"
        }.ToAsyncEnumerable());
        _lineAnalyser.Analyse("line1").Returns(LineStatus.Incomplete);
        _lineAnalyser.Analyse("line2").Returns(LineStatus.IllegalParenthese);
        _lineAnalyser.Analyse("line3").Returns(LineStatus.Good);

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(3);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenInputContains1IllegalSquareBracket_ThenReturns57()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "line1", "line2", "line3"
        }.ToAsyncEnumerable());
        _lineAnalyser.Analyse("line1").Returns(LineStatus.Incomplete);
        _lineAnalyser.Analyse("line2").Returns(LineStatus.IllegalSquareBracket);
        _lineAnalyser.Analyse("line3").Returns(LineStatus.Good);

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(57);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenInputContains1IllegalBrace_ThenReturns1197()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "line1", "line2", "line3"
        }.ToAsyncEnumerable());
        _lineAnalyser.Analyse("line1").Returns(LineStatus.Incomplete);
        _lineAnalyser.Analyse("line2").Returns(LineStatus.IllegalBrace);
        _lineAnalyser.Analyse("line3").Returns(LineStatus.Good);

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(1197);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenInputContains1IllegalChevron_ThenReturns25137()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "line1", "line2", "line3"
        }.ToAsyncEnumerable());
        _lineAnalyser.Analyse("line1").Returns(LineStatus.Incomplete);
        _lineAnalyser.Analyse("line2").Returns(LineStatus.IllegalChevron);
        _lineAnalyser.Analyse("line3").Returns(LineStatus.Good);

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(25137);
    }

    [Fact]
    public async Task SolveBonusProblemAsync_WhenInputContains1IncompleteLine_ThenReturnsThisLineScore()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "line1", "line2", "line3"
        }.ToAsyncEnumerable());
        _lineAnalyser.Analyse("line1").Returns(LineStatus.Incomplete);
        _lineAnalyser.Analyse("line2").Returns(LineStatus.IllegalChevron);
        _lineAnalyser.Analyse("line3").Returns(LineStatus.Good);
        _lineAnalyser.CalculateLineCompletionScore("line1").Returns(10);

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(10);
    }

    [Fact]
    public async Task SolveBonusProblemAsync_WhenInputContains3IncompleteLines_ThenReturnsMiddleScore()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "line1", "line2", "line3"
        }.ToAsyncEnumerable());
        _lineAnalyser.Analyse("line1").Returns(LineStatus.Incomplete);
        _lineAnalyser.Analyse("line2").Returns(LineStatus.Incomplete);
        _lineAnalyser.Analyse("line3").Returns(LineStatus.Incomplete);
        _lineAnalyser.CalculateLineCompletionScore("line1").Returns(10);
        _lineAnalyser.CalculateLineCompletionScore("line2").Returns(100);
        _lineAnalyser.CalculateLineCompletionScore("line3").Returns(1000);

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(100);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]"
        }.ToAsyncEnumerable());
        var subject = new Day10Solver(_rawInputProvider, new LineAnalyser());

        var result = await subject.SolveProblemAsync();

        result.Should().Be(26397);
    }
}
