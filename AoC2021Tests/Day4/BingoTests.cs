using System;
using System.Collections.Generic;
using AoC2021.Day4;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day4;

public class BingoTests
{
    [Fact]
    public void Bingo_ThenBingoHasNotWonAndNoUnmarkedCellsTotal()
    {
        var subject = new Bingo();

        subject.HasWon.Should().BeFalse();
        subject.UnmarkedCellsTotal.Should().BeNull();
    }

    [Fact]
    public void LoadCells_When4Lines_ThenArgumentException()
    {
        var lines = new List<string> { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20" };
        var subject = new Bingo();

        var action = () => subject.LoadCells(lines);

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LoadCells_When6Lines_ThenArgumentException()
    {
        var lines = new List<string> { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25", "26 27 28 29 30" };
        var subject = new Bingo();

        var action = () => subject.LoadCells(lines);

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LoadCells_When5LinesAnd1LineDoesNotHave5Numbers_ThenArgumentException()
    {
        var lines = new List<string> { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 19 20", "21 22 23 24 25" };
        var subject = new Bingo();

        var action = () => subject.LoadCells(lines);

        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void LoadCells_When5LinesAndAllLinesHave5Numbers_ThenCellsLoadedSuccessfullys()
    {
        var lines = new List<string> { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" };
        var subject = new Bingo();

        subject.LoadCells(lines);

        subject.Cells[0, 0].Value.Should().Be(1);
        subject.Cells[1, 0].Value.Should().Be(6);
        subject.Cells[2, 4].Value.Should().Be(15);
        subject.Cells[4, 3].Value.Should().Be(24);
        subject.Cells[4, 4].Value.Should().Be(25);
    }

    [Fact]
    public void NewNumberDrawed_1CellHasNewNumberValue_ThenThatCellBecomesMarked()
    {
        var lines = new List<string> { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" };
        var subject = new Bingo();
        subject.LoadCells(lines);

        subject.NewNumberDrawed(9);

        subject.Cells[1, 3].IsMarked.Should().BeTrue();
    }

    [Fact]
    public void NewNumberDrawed_WhenNoLineAndNoColumnIsFullyMarked_ThenBingoHasNotWonYet()
    {
        var lines = new List<string> { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" };
        var subject = new Bingo();
        subject.LoadCells(lines);

        subject.NewNumberDrawed(1);
        subject.NewNumberDrawed(2);
        subject.NewNumberDrawed(3);
        subject.NewNumberDrawed(4);
        subject.NewNumberDrawed(6);
        subject.NewNumberDrawed(11);
        subject.NewNumberDrawed(16);

        subject.HasWon.Should().BeFalse();
        subject.UnmarkedCellsTotal.Should().BeNull();
    }

    [Fact]
    public void NewNumberDrawed_WhenALineBecomesFullyMarked_ThenBingoHasWon()
    {
        var lines = new List<string> { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" };
        var subject = new Bingo();
        subject.LoadCells(lines);

        subject.NewNumberDrawed(1);
        subject.NewNumberDrawed(2);
        subject.NewNumberDrawed(3);
        subject.NewNumberDrawed(4);
        subject.NewNumberDrawed(6);
        subject.NewNumberDrawed(11);
        subject.NewNumberDrawed(16);
        subject.NewNumberDrawed(5);

        subject.HasWon.Should().BeTrue();
        subject.UnmarkedCellsTotal.Should().Be(277);
    }

    [Fact]
    public void NewNumberDrawed_WhenAColumnBecomesFullyMarked_ThenBingoHasWon()
    {
        var lines = new List<string> { " 1  2  3  4  5", " 6  7  8  9 10", "11 12 13 14 15", "16 17 18 19 20", "21 22 23 24 25" };
        var subject = new Bingo();
        subject.LoadCells(lines);

        subject.NewNumberDrawed(1);
        subject.NewNumberDrawed(2);
        subject.NewNumberDrawed(3);
        subject.NewNumberDrawed(4);
        subject.NewNumberDrawed(6);
        subject.NewNumberDrawed(11);
        subject.NewNumberDrawed(16);
        subject.NewNumberDrawed(21);

        subject.HasWon.Should().BeTrue();
        subject.UnmarkedCellsTotal.Should().Be(261);
    }
}
