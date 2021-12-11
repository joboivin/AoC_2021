using System;
using AoC2021.Day11;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace AoC2021Tests.Day11;

public class OctopusTests
{
    [Fact]
    public void Octopus_ThenEnergyIsInitialEnergy()
    {
        const int energy = 5;

        var subject = new Octopus(energy, () => { });

        subject.Energy.Should().Be(energy);
    }

    [Fact]
    public void IncreaseEnergy_ThenIncreasesEnergyBy1()
    {
        const int energy = 5;

        var subject = new Octopus(energy, () => { });

        subject.IncreaseEnergy();

        subject.Energy.Should().Be(energy + 1);
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsSmallerThanFlashLevel_ThenOctopusDoesNotFlash()
    {
        var flash = Substitute.For<Action>();
        var subject = new Octopus(Octopus.FlashEnergyLevel - 2, flash);

        subject.IncreaseEnergy();

        flash.DidNotReceive().Invoke();
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsEqualToFlashLevel_ThenOctopusDoesNotFlash()
    {
        var flash = Substitute.For<Action>();
        var subject = new Octopus(Octopus.FlashEnergyLevel - 1, flash);

        subject.IncreaseEnergy();

        flash.DidNotReceive().Invoke();
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsGeaterThanFlashLevel_ThenOctopusFlashes()
    {
        var flash = Substitute.For<Action>();
        var subject = new Octopus(Octopus.FlashEnergyLevel, flash);

        subject.IncreaseEnergy();

        flash.Received().Invoke();
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsSmallerThanFlashLevel_ThenAdjacentOctopusesDoNotIncreaseTheirEnergy()
    {
        const int adjacentEnergy = 2;

        var adjacent = new Octopus(adjacentEnergy, () => { });
        var subject = new Octopus(Octopus.FlashEnergyLevel - 2, () => { });
        subject.AddAdjacentOctopus(adjacent);

        subject.IncreaseEnergy();

        adjacent.Energy.Should().Be(adjacentEnergy);
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsEqualToFlashLevel_ThenAdjacentOctopusesDoNotIncreaseTheirEnergy()
    {
        const int adjacentEnergy = 2;

        var adjacent = new Octopus(adjacentEnergy, () => { });
        var subject = new Octopus(Octopus.FlashEnergyLevel - 1, () => { });
        subject.AddAdjacentOctopus(adjacent);

        subject.IncreaseEnergy();

        adjacent.Energy.Should().Be(adjacentEnergy);
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsGeaterThanFlashLevel_ThenAdjacentOctopusesIncreaseTheirEnergy()
    {
        const int adjacentEnergy = 2;

        var adjacent = new Octopus(adjacentEnergy, () => { });
        var subject = new Octopus(Octopus.FlashEnergyLevel, () => { });
        subject.AddAdjacentOctopus(adjacent);

        subject.IncreaseEnergy();

        adjacent.Energy.Should().Be(adjacentEnergy + 1);
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsGeaterThanFlashLevelAnd2AdjacentOctopuses_ThenAdjacentOctopusesIncreaseTheirEnergy()
    {
        const int adjacentEnergy = 2;

        var adjacent1 = new Octopus(adjacentEnergy, () => { });
        var adjacent2 = new Octopus(adjacentEnergy, () => { });
        var subject = new Octopus(Octopus.FlashEnergyLevel, () => { });
        subject.AddAdjacentOctopus(adjacent1);
        subject.AddAdjacentOctopus(adjacent2);

        subject.IncreaseEnergy();

        adjacent1.Energy.Should().Be(adjacentEnergy + 1);
        adjacent2.Energy.Should().Be(adjacentEnergy + 1);
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsGeaterThanFlashLevelAndAdjacentOctopusFinalEnergyIsSmallerThanFlashLevel_ThenAdjacentOctopusDoesNotFlash()
    {
        var flash = Substitute.For<Action>();
        var adjacent = new Octopus(Octopus.FlashEnergyLevel - 2, flash);
        var subject = new Octopus(Octopus.FlashEnergyLevel, () => { });
        subject.AddAdjacentOctopus(adjacent);

        subject.IncreaseEnergy();

        flash.DidNotReceive().Invoke();
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsGeaterThanFlashLevelAndAdjacentOctopusFinalEnergyIsGreaterThanFlashLevel_ThenAdjacentOctopusFlashes()
    {
        var flash = Substitute.For<Action>();
        var adjacent = new Octopus(Octopus.FlashEnergyLevel, flash);
        var subject = new Octopus(Octopus.FlashEnergyLevel, () => { });
        subject.AddAdjacentOctopus(adjacent);

        subject.IncreaseEnergy();

        flash.Received().Invoke();
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsGeaterThanFlashLevelAndAdjacentOctopusFinalEnergyIsGreaterThanFlashLevelAndAdjacentOctopusHasAdjacentOctopus_ThenAdjacentOctopusesIncreaseTheirEnergy()
    {
        const int adjacentEnergy = 3;

        var adjacentAdjacent = new Octopus(adjacentEnergy, () => { });
        var adjacent = new Octopus(Octopus.FlashEnergyLevel, () => { });
        adjacent.AddAdjacentOctopus(adjacentAdjacent);
        var subject = new Octopus(Octopus.FlashEnergyLevel, () => { });
        subject.AddAdjacentOctopus(adjacent);

        subject.IncreaseEnergy();

        adjacentAdjacent.Energy.Should().Be(adjacentEnergy + 1);
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsGeaterThanFlashLevelAndAdjacentOctopusFinalEnergyIsGreaterThanFlashLevel_ThenInitialOctopusDoesNotFlashTwice()
    {
        var flash = Substitute.For<Action>();
        var adjacent = new Octopus(Octopus.FlashEnergyLevel, () => { });
        var subject = new Octopus(Octopus.FlashEnergyLevel, flash);
        subject.AddAdjacentOctopus(adjacent);
        adjacent.AddAdjacentOctopus(subject);

        subject.IncreaseEnergy();

        flash.Received(1).Invoke();
    }

    [Fact]
    public void IncreaseEnergy_WhenFinalEnergyIsGeaterThanFlashLevelAndAdjacentOctopusFinalEnergyIsGreaterThanFlashLevelAndSubjectAndAdjacentBothHaveSameAdjacent_ThenThisAdjacentIncreasesEnergyTwoTimes()
    {
        const int adjacentEnergy = 3;

        var adjacentAdjacent = new Octopus(adjacentEnergy, () => { });
        var adjacent = new Octopus(Octopus.FlashEnergyLevel, () => { });
        var subject = new Octopus(Octopus.FlashEnergyLevel, () => { });
        subject.AddAdjacentOctopus(adjacent);
        subject.AddAdjacentOctopus(adjacentAdjacent);
        adjacent.AddAdjacentOctopus(adjacentAdjacent);

        subject.IncreaseEnergy();

        adjacentAdjacent.Energy.Should().Be(adjacentEnergy + 2);
    }

    [Fact]
    public void PerformEndOfStep_WhenFinalEnergyIsSmallerThanFlashLevel_ThenEnergyRemainsSame()
    {
        var subject = new Octopus(Octopus.FlashEnergyLevel - 2, () => { });
        subject.IncreaseEnergy();

        subject.PerformEndOfStep();

        subject.Energy.Should().Be(Octopus.FlashEnergyLevel - 1);
    }

    [Fact]
    public void PerformEndOfStep_WhenFinalEnergyIsEqualToFlashLevel_ThenEnergyRemainsSame()
    {
        var subject = new Octopus(Octopus.FlashEnergyLevel - 1, () => { });
        subject.IncreaseEnergy();

        subject.PerformEndOfStep();

        subject.Energy.Should().Be(Octopus.FlashEnergyLevel);
    }

    [Fact]
    public void PerformEndOfStep_WhenFinalEnergyIsSmallerGreaterThanFlashLevel_ThenEnergyReturnsTo0()
    {
        var subject = new Octopus(Octopus.FlashEnergyLevel, () => { });
        subject.IncreaseEnergy();

        subject.PerformEndOfStep();

        subject.Energy.Should().Be(0);
    }
}
