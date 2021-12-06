using System;
using AoC2021.Day5;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace AoC2021Tests.Day5;

public class HydrothermalVentPointsProviderTests
{
    [Fact]
    public void ProvidePoints_WhenInputDoesntMatchExpectedPattern_ThenThrowsException()
    {
        var subject = new HydrothermalVentPointsProvider();

        var action = () => subject.ProvidePoints("0,4 ->9,7");

        action.Should().Throw<Exception>();
    }

    [Fact]
    public void ProvidePoints_WhenInputRepresentsIncreasingHorizontalLine_ThenReturnsExpectedPoints()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvidePoints("2,3 -> 2,6");

        using (new AssertionScope())
        {
            result.Should().HaveCount(4);
            result.Should().Contain((2, 3));
            result.Should().Contain((2, 4));
            result.Should().Contain((2, 5));
            result.Should().Contain((2, 6));
        }
    }

    [Fact]
    public void ProvidePoints_WhenInputRepresentsDecreasingHorizontalLine_ThenReturnsExpectedPoints()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvidePoints("2,4 -> 2,2");

        using (new AssertionScope())
        {
            result.Should().HaveCount(3);
            result.Should().Contain((2, 2));
            result.Should().Contain((2, 3));
            result.Should().Contain((2, 4));
        }
    }

    [Fact]
    public void ProvidePoints_WhenInputRepresentsIncreasingVerticalLine_ThenReturnsExpectedPoints()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvidePoints("10,3 -> 14,3");

        using (new AssertionScope())
        {
            result.Should().HaveCount(5);
            result.Should().Contain((10, 3));
            result.Should().Contain((11, 3));
            result.Should().Contain((12, 3));
            result.Should().Contain((13, 3));
            result.Should().Contain((14, 3));
        }
    }

    [Fact]
    public void ProvidePoints_WhenInputRepresentsDecreasingVerticalLine_ThenReturnsExpectedPoints()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvidePoints("12,4 -> 11,4");

        using (new AssertionScope())
        {
            result.Should().HaveCount(2);
            result.Should().Contain((12, 4));
            result.Should().Contain((11, 4));
        }
    }

    [Fact]
    public void ProvidePoints_WhenInputRepresentsDiagonalLine_ThenReturnsEmptyList()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvidePoints("3,4 -> 5,6");

        result.Should().BeEmpty();
    }

    [Fact]
    public void ProvideAllPoints_WhenInputRepresentsHorizontallyIncreasingAndVerticallyIncreasingDiagonalLine_ThenReturnsExpectedPoints()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvideAllPoints("3,4 -> 5,6");

        using (new AssertionScope())
        {
            result.Should().HaveCount(3);
            result.Should().Contain((3, 4));
            result.Should().Contain((4, 5));
            result.Should().Contain((5, 6));
        }
    }

    [Fact]
    public void ProvideAllPoints_WhenInputRepresentsHorizontallyIncreasingAndVerticallyDecreasingDiagonalLine_ThenReturnsExpectedPoints()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvideAllPoints("5,4 -> 8,1");

        using (new AssertionScope())
        {
            result.Should().HaveCount(4);
            result.Should().Contain((5, 4));
            result.Should().Contain((6, 3));
            result.Should().Contain((7, 2));
            result.Should().Contain((8, 1));
        }
    }

    [Fact]
    public void ProvideAllPoints_WhenInputRepresentsHorizontallyDecreasingAndVerticallyIncreasingDiagonalLine_ThenReturnsExpectedPoints()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvideAllPoints("8,5 -> 7,6");

        using (new AssertionScope())
        {
            result.Should().HaveCount(2);
            result.Should().Contain((8, 5));
            result.Should().Contain((7, 6));
        }
    }

    [Fact]
    public void ProvideAllPoints_WhenInputRepresentsHorizontallyDecreasingAndVerticallyDecreasingDiagonalLine_ThenReturnsExpectedPoints()
    {
        var subject = new HydrothermalVentPointsProvider();

        var result = subject.ProvideAllPoints("10,9 -> 6,5");

        using (new AssertionScope())
        {
            result.Should().HaveCount(5);
            result.Should().Contain((10, 9));
            result.Should().Contain((9, 8));
            result.Should().Contain((8, 7));
            result.Should().Contain((7, 6));
            result.Should().Contain((6, 5));
        }
    }
}
