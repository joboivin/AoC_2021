using AoC2021.Day4;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day4;

public class BingoCellTests
{
    [Fact]
    public void BingoCell_ThenCellHasValueAndIsNotMarked()
    {
        const int cellValue = 10;

        var subject = new BingoCell(cellValue);

        subject.IsMarked.Should().BeFalse();
        subject.Value.Should().Be(cellValue);
    }

    [Fact]
    public void NewNumberDrawed_WhenNewNumberIsCellValue_ThenCellBecomesMarked()
    {
        const int cellValue = 20;
        var subject = new BingoCell(cellValue);

        subject.NewNumberDrawed(cellValue);

        subject.IsMarked.Should().BeTrue();
    }

    [Fact]
    public void NewNumberDrawed_WhenNewNumberIsNotCellValue_ThenCellStaysUnmarked()
    {
        const int cellValue = 20;
        var subject = new BingoCell(cellValue - 1);

        subject.NewNumberDrawed(cellValue);

        subject.IsMarked.Should().BeFalse();
    }
}

