using AoC2021.Day10;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day10;

public class LineAnalyserTests
{
    [Theory]
    [InlineData("([])")]
    [InlineData("{()()()}")]
    [InlineData("<([{}])>")]
    [InlineData("[<>({}){}[([])<>]]")]
    [InlineData("(((((((((())))))))))")]
    public void Analyse_WhenLineIsGood_ThenReturnsGood(string goodLine)
    {
        var subject = new LineAnalyser();

        var result = subject.Analyse(goodLine);

        result.Should().Be(LineStatus.Good);
    }

    [Theory]
    [InlineData("[({(<(())[]>[[{[]{<()<>>")]
    [InlineData("[(()[<>])]({[<{<<[]>>(")]
    [InlineData("(((({<>}<{<{<>}{[]{[]{}")]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]")]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]")]
    public void Analyse_WhenLineIsIncomplete_ThenReturnsIncomplete(string incompleteLine)
    {
        var subject = new LineAnalyser();

        var result = subject.Analyse(incompleteLine);

        result.Should().Be(LineStatus.Incomplete);
    }

    [Fact]
    public void Analyse_WhenLFirstIllegalBracketIsParenthese_ThenReturnsIllegalParenthese()
    {
        var subject = new LineAnalyser();

        var result = subject.Analyse("[[<[([]))<([[{}[[()]]]");

        result.Should().Be(LineStatus.IllegalParenthese);
    }

    [Fact]
    public void Analyse_WhenFirstIllegalBracketIsSquareBracket_ThenReturnsIllegalSquareBracket()
    {
        var subject = new LineAnalyser();

        var result = subject.Analyse("[{[{({}]{}}([{[{{{}}([]");

        result.Should().Be(LineStatus.IllegalSquareBracket);
    }

    [Fact]
    public void Analyse_WhenFirstIllegalBracketIsBrace_ThenReturnsIllegalBrace()
    {
        var subject = new LineAnalyser();

        var result = subject.Analyse("{([(<{}[<>[]}>{[]{[(<()>");

        result.Should().Be(LineStatus.IllegalBrace);
    }

    [Fact]
    public void Analyse_WhenFirstIllegalBracketIsChevron_ThenReturnsIllegalChevron()
    {
        var subject = new LineAnalyser();

        var result = subject.Analyse("<{([([[(<>()){}]>(<<{{");

        result.Should().Be(LineStatus.IllegalChevron);
    }

    [Fact]
    public void CalculateLineCompletionScore_WhenOnlyMissingParenthese_ThenReturns1()
    {
        var subject = new LineAnalyser();

        var result = subject.CalculateLineCompletionScore("(([[]])");

        result.Should().Be(1);
    }

    [Fact]
    public void CalculateLineCompletionScore_WhenOnlyMissingSquareBracket_ThenReturns2()
    {
        var subject = new LineAnalyser();

        var result = subject.CalculateLineCompletionScore("[([[]])");

        result.Should().Be(2);
    }

    [Fact]
    public void CalculateLineCompletionScore_WhenOnlyMissingBrace_ThenReturns3()
    {
        var subject = new LineAnalyser();

        var result = subject.CalculateLineCompletionScore("{([[]])");

        result.Should().Be(3);
    }

    [Fact]
    public void CalculateLineCompletionScore_WhenOnlyMissingChevron_ThenReturns4()
    {
        var subject = new LineAnalyser();

        var result = subject.CalculateLineCompletionScore("<([[]])");

        result.Should().Be(4);
    }

    [Theory]
    [InlineData("[({(<(())[]>[[{[]{<()<>>", 288957)]
    [InlineData("[(()[<>])]({[<{<<[]>>(", 5566)]
    [InlineData("(((({<>}<{<{<>}{[]{[]{}", 1480781)]
    [InlineData("{<[[]]>}<{[{[{[]{()[[[]", 995444)]
    [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", 294)]
    public void CalculateLineCompletionScore_WhenMissingAFewBrackets_ThenReturnsExpectedScore(string line, int expectedScore)
    {
        var subject = new LineAnalyser();

        var result = subject.CalculateLineCompletionScore(line);

        result.Should().Be(expectedScore);
    }
}
