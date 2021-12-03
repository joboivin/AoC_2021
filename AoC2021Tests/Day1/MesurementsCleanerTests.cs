using System.Linq;
using System.Threading.Tasks;
using AoC2021.Day1;
using FluentAssertions;
using Xunit;

namespace AoC2021Tests.Day1;

public class MesurementsCleanerTests
{
    private readonly MesurementsCleaner _subject;

    public MesurementsCleanerTests()
    {
        _subject = new MesurementsCleaner();
    }

    [Fact]
    public async Task CleanMesurementsAsync_When3Mesurements_ThenReturns1MesurementsWhichIsTheSum()
    {
        var result = await _subject.CleanMesurementsAsync(new[] { 12, 13, 14 }.ToAsyncEnumerable());

        result.Should().ContainSingle().Which.Should().Be(39);
    }

    [Fact]
    public async Task CleanMesurementsAsync_When4Mesurements_ThenReturns2Mesurements()
    {
        var result = await _subject.CleanMesurementsAsync(new[] { 12, 13, 14, 15 }.ToAsyncEnumerable());

        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task CleanMesurementsAsync_When4Mesurements_ThenFirstReturnesMesurementIsTheSumOfFirst3Mesurements()
    {
        var result = await _subject.CleanMesurementsAsync(new[] { 12, 13, 14, 15 }.ToAsyncEnumerable());

        result[0].Should().Be(39);
    }

    [Fact]
    public async Task CleanMesurementsAsync_When4Mesurements_ThenFirstReturnesMesurementIsTheSumOfLast3Mesurements()
    {
        var result = await _subject.CleanMesurementsAsync(new[] { 12, 13, 14, 15 }.ToAsyncEnumerable());

        result[1].Should().Be(42);
    }
}
