using System;
using AoC2021.Day8;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day8;

public class DigitValuesFinderTests
{
    [Theory]
    [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb")]
    [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab ab")]
    public void FindDigitValues_WhenInputDoesNotHave10Digits_ThenThrowsException(string input)
    {
        var subject = new DigitValuesFinder();

        var action = () => subject.FindDigitValues(input);

        action.Should().Throw<Exception>();
    }

    [Fact]
    public void FindDigitValues_WhenInputHas10Digits_ThenReturns10Digits()
    {
        var subject = new DigitValuesFinder();

        var result = subject.FindDigitValues("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab");

        result.Should().HaveCount(10);
    }

    [Fact]
    public void FindDigitValues_WhenInputHas10Digits_ThenEasyDigitsAreFound()
    {
        var subject = new DigitValuesFinder();

        var result = subject.FindDigitValues("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab");

        result.Should().Contain(d => d.Segments == "ab" && d.Value == 1, "1 is the only number with 2 segments");
        result.Should().Contain(d => d.Segments == "acedgfb" && d.Value == 8, "8 is the only number with 7 segments");
        result.Should().Contain(d => d.Segments == "eafb" && d.Value == 4, "4 is the only number with 4 segments");
        result.Should().Contain(d => d.Segments == "dab" && d.Value == 7, "7 is the only number with 3 segments");
    }

    [Fact]
    public void FindDigitValues_WhenInputHas10Digits_Then9IsFound()
    {
        var subject = new DigitValuesFinder();

        var result = subject.FindDigitValues("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab");

        result.Should().Contain(d => d.Segments == "cefabd" && d.Value == 9);
    }

    [Fact]
    public void FindDigitValues_WhenInputHas10Digits_Then3IsFound()
    {
        var subject = new DigitValuesFinder();

        var result = subject.FindDigitValues("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab");

        result.Should().Contain(d => d.Segments == "fbcad" && d.Value == 3);
    }

    [Fact]
    public void FindDigitValues_WhenInputHas10Digits_Then0IsFound()
    {
        var subject = new DigitValuesFinder();

        var result = subject.FindDigitValues("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab");

        result.Should().Contain(d => d.Segments == "cagedb" && d.Value == 0);
    }

    [Fact]
    public void FindDigitValues_WhenInputHas10Digits_Then6IsFound()
    {
        var subject = new DigitValuesFinder();

        var result = subject.FindDigitValues("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab");

        result.Should().Contain(d => d.Segments == "cdfgeb" && d.Value == 6);
    }

    [Fact]
    public void FindDigitValues_WhenInputHas10Digits_Then5IsFound()
    {
        var subject = new DigitValuesFinder();

        var result = subject.FindDigitValues("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab");

        result.Should().Contain(d => d.Segments == "cdfbe" && d.Value == 5);
    }

    [Fact]
    public void FindDigitValues_WhenInputHas10Digits_Then2IsFound()
    {
        var subject = new DigitValuesFinder();

        var result = subject.FindDigitValues("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab");

        result.Should().Contain(d => d.Segments == "gcdfa" && d.Value == 2);
    }
}
