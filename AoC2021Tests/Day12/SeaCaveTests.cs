using AoC2021.Day12;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day12;

public class SeaCaveTests
{
    [Fact]
    public void SeaCave_ThenConnectedCavesIsEmpty()
    {
        var subject = new SeaCave("");

        subject.ConnectedCaves.Should().BeEmpty();
    }

    [Fact]
    public void IsWorthVisitingMoreThanOnce_WhenNAmeIsAllUpperCase_ThenReturnsTrue()
    {
        var subject = new SeaCave("ABCDEFXYZ");

        var result = subject.IsWorthVisitingMoreThanOnce;

        result.Should().BeTrue();
    }

    [Fact]
    public void IsWorthVisitingMoreThanOnce_WhenNameIsAllUpperLowerCase_ThenReturnsFalse()
    {
        var subject = new SeaCave("abcdefxyz");

        var result = subject.IsWorthVisitingMoreThanOnce;

        result.Should().BeFalse();
    }

    [Fact]
    public void IsWorthVisitingMoreThanOnce_WhenNameIsMixOfUpperCaseAndLowerCase_ThenReturnsFalse()
    {
        var subject = new SeaCave("AbCDEFXyZ");

        var result = subject.IsWorthVisitingMoreThanOnce;

        result.Should().BeFalse();
    }

    [Fact]
    public void AddConnectedCave_ThenCaveIsAddedToConnectedCaves()
    {
        var subject = new SeaCave("Cave1");
        var connectedCave = new SeaCave("Cave2");

        subject.AddConnectedCave(connectedCave);

        subject.ConnectedCaves.Should().Contain(connectedCave);
    }
}
