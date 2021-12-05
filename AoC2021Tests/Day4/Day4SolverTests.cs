using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AoC2021.Day4;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day4;

public class Day4SolverTests
{
    private readonly IBingoCreator _bingoCreator;

    private readonly Day4Solver _subject;

    public Day4SolverTests()
    {
        _bingoCreator = Substitute.For<IBingoCreator>();

        _subject = new Day4Solver(_bingoCreator);
    }

    [Fact]
    public async Task SolveProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        SetupBingoCreator();

        var result = await _subject.SolveProblemAsync();

        result.Should().Be(4512);
    }

    [Fact]
    public void SolveProblemAsync_WhenNoBoardWins_ThenException()
    {
        SetupBingoCreatorWithoutWinner();

        var action = () => _subject.SolveProblemAsync();

        action.Should().Throw<Exception>();
    }

    [Fact]
    public async Task SolveBonusProblemAsync_WhenUsingAoCInput_ThenReturnsAoCResult()
    {
        SetupBingoCreator();

        var result = await _subject.SolveBonusProblemAsync();

        result.Should().Be(1924);
    }

    [Fact]
    public void SolveBonusProblemAsync_When1BoardNeverWins_ThenException()
    {
        SetupBingoCreatorWhere1BoardNeverWins();

        var action = () => _subject.SolveBonusProblemAsync();

        action.Should().Throw<Exception>();
    }

    private void SetupBingoCreator()
    {
        _bingoCreator.CreateBingoBoardsAsync().Returns((
            new List<Bingo> { CreateBingo1(), CreateBingo2(), CreateBingo3() },
            new List<int> { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 })
            );
    }

    private void SetupBingoCreatorWithoutWinner()
    {
        _bingoCreator.CreateBingoBoardsAsync().Returns((
            new List<Bingo> { CreateBingo1(), CreateBingo2(), CreateBingo3() },
            new List<int> { 7, 4, 9, 5 })
            );
    }

    private void SetupBingoCreatorWhere1BoardNeverWins()
    {
        _bingoCreator.CreateBingoBoardsAsync().Returns((
            new List<Bingo> { CreateBingo1(), CreateBingo2(), CreateBingo3() },
            new List<int> { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16 })
            );
    }

    private Bingo CreateBingo1()
    {
        var board = new Bingo();
        board.LoadCells(new[] { "22 13 17 11  0", " 8  2 23  4 24", "21  9 14 16  7", " 6 10  3 18  5", " 1 12 20 15 19" });

        return board;
    }

    private Bingo CreateBingo2()
    {
        var board = new Bingo();
        board.LoadCells(new[] { " 3 15  0  2 22", " 9 18 13 17  5", "19  8  7 25 23", "20 11 10 24  4", "14 21 16 12  6" });

        return board;
    }

    private Bingo CreateBingo3()
    {
        var board = new Bingo();
        board.LoadCells(new[] { "14 21 17 24  4", "10 16 15  9 19", "18  8 23 26 20", "22 11 13  6  5", " 2  0 12  3  7" });

        return board;
    }
}
