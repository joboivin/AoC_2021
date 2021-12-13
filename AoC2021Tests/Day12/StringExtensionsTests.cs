using AoC2021.Day12;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day12;

public class StringExtensionsTests
{
    [Fact]
    public void IsUpperCase_WhenStringIsAllUpperCase_ThenReturnsTrue()
    {
        var subject = "ABCDEFXYZ";

        var result = subject.IsUpperCase();

        result.Should().BeTrue();
    }

    [Fact]
    public void IsUpperCase_WhenStringIsAllUpperLowerCase_ThenReturnsFalse()
    {
        var subject = "abcdefxyz";

        var result = subject.IsUpperCase();

        result.Should().BeFalse();
    }

    [Fact]
    public void IsUpperCase_WhenStringIsMixOfUpperCaseAndLowerCase_ThenReturnsFalse()
    {
        var subject = "AbCDEFXyZ";

        var result = subject.IsUpperCase();

        result.Should().BeFalse();
    }
}
