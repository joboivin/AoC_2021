using System.Linq;
using System.Threading.Tasks;
using AoC2021.Common;
using AoC2021.Day4;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day4;

public class BingoCreatorTests
{
    private readonly IRawInputProvider _rawInputProvider;

    private readonly BingoCreator _subject;

    public BingoCreatorTests()
    {
        _rawInputProvider = Substitute.For<IRawInputProvider>();

        _subject = new BingoCreator(_rawInputProvider);
    }

    [Fact]
    public async Task CreateBingoBoardsAsync_ThenFirstLineBecomesNumbersToBeDrawed()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "", "22 13 17 11  0", " 8  2 23  4 24", "21  9 14 16  7", " 6 10  3 18  5", " 1 12 20 15 19"}.ToAsyncEnumerable());

        var result = await _subject.CreateBingoBoardsAsync();

        var numbersToBeDrawed = result.numbersToBeDrawed;
        numbersToBeDrawed.Should().HaveCount(27);
        numbersToBeDrawed[0].Should().Be(7);
        numbersToBeDrawed[10].Should().Be(21);
        numbersToBeDrawed[21].Should().Be(20);
    }

    [Fact]
    public async Task CreateBingoBoardsAsync_WhenInputContains1Board_ThenReturns1Board()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "", "22 13 17 11  0", " 8  2 23  4 24", "21  9 14 16  7", " 6 10  3 18  5", " 1 12 20 15 19"}.ToAsyncEnumerable());

        var result = await _subject.CreateBingoBoardsAsync();

        result.bingoBoards.Should().ContainSingle();
        var createdBoard = result.bingoBoards.Single();
        createdBoard.Cells[0, 0].Value.Should().Be(22);
    }

    [Fact]
    public async Task CreateBingoBoardsAsync_WhenInputContains2Boards_ThenReturns2Boards()
    {
        _rawInputProvider.ProvideRawInputAsync().Returns(new[] { "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "", "22 13 17 11  0", " 8  2 23  4 24", "21  9 14 16  7", " 6 10  3 18  5", " 1 12 20 15 19",
            "", " 3 15  0  2 22", " 9 18 13 17  5", "19  8  7 25 23", "20 11 10 24  4", "14 21 16 12  6"}.ToAsyncEnumerable());

        var result = await _subject.CreateBingoBoardsAsync();

        result.bingoBoards.Should().HaveCount(2);
        result.bingoBoards[0].Cells[0, 0].Value.Should().Be(22);
        result.bingoBoards[1].Cells[0, 0].Value.Should().Be(3);
    }
}
