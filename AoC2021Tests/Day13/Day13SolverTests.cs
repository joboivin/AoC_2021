using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day13;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day13;

public class Day13SolverTests
{
    private readonly IPaperProvider _paperProvider;
    private readonly IConsole _console;

    private readonly Day13Solver _subject;

    public Day13SolverTests()
    {
        _paperProvider = Substitute.For<IPaperProvider>();
        _console = Substitute.For<IConsole>();

        _subject = new Day13Solver(_paperProvider, _console);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenBasicExampleFoldingAlongX_ThenReturns1()
    {
        var paper = new bool[3, 3];
        paper[0, 2] = true;
        _paperProvider.ProvidePaperAsync().Returns((paper, new List<string> { "fold along x=1" }));

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(1);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenMoreAdvancedExampleFoldingAlongX_ThenReturns3()
    {
        var paper = new bool[3, 3];
        paper[2, 0] = true;
        paper[0, 0] = true;
        paper[0, 2] = true;
        _paperProvider.ProvidePaperAsync().Returns((paper, new List<string> { "fold along x=1" }));

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(2);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenBasicExampleFoldingAlongY_ThenReturns1()
    {
        var paper = new bool[3, 3];
        paper[2, 0] = true;
        _paperProvider.ProvidePaperAsync().Returns((paper, new List<string> { "fold along y=1" }));

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(1);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenMoreAdvancedExampleFoldingAlongY_ThenReturns3()
    {
        var paper = new bool[3, 3];
        paper[2, 0] = true;
        paper[0, 0] = true;
        paper[0, 2] = true;
        _paperProvider.ProvidePaperAsync().Returns((paper, new List<string> { "fold along y=1" }));

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(2);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        var subject = CreateAoCSubject();

        var result = await subject.SolveProblemAsync();

        result.Should().Be(17);
    }

    [Fact, Trait("Category", "Functional")]
    public async Task SolveBonusProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        var subject = CreateAoCSubject();

        var result = await subject.SolveBonusProblemAsync();

        result.Should().Be(-1);

        Received.InOrder(() =>
        {
            _console.WriteLine("#####");
            _console.WriteLine("#...#");
            _console.WriteLine("#...#");
            _console.WriteLine("#...#");
            _console.WriteLine("#####");
            _console.WriteLine(".....");
            _console.WriteLine(".....");
        });
    }

    private Day13Solver CreateAoCSubject()
    {
        var rawInputProvider = Substitute.For<IRawInputProvider>();
        rawInputProvider.ProvideRawInputAsync().Returns(new[]
        {
            "6,10",
            "0,14",
            "9,10",
            "0,3",
            "10,4",
            "4,11",
            "6,0",
            "6,12",
            "4,1",
            "0,13",
            "10,12",
            "3,4",
            "3,0",
            "8,4",
            "1,10",
            "2,14",
            "8,10",
            "9,0",
            "",
            "fold along y=7",
            "fold along x=5"
        }.ToAsyncEnumerable());

        return new Day13Solver(new PaperProvider(rawInputProvider), _console);
    }
}
