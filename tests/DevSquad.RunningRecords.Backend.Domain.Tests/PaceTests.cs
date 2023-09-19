using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace DevSquad.RunningRecords.Backend.Domain.Tests;

public class PaceTests
{
    [Fact]
    public void Constructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var durationPerUnit = TimeSpan.FromMinutes(5);
        var unit = DistanceUnits.Mi;

        // Act
        var pace = new Pace(durationPerUnit, unit);

        // Assert
        pace.DurationPerUnit.Should().Be(durationPerUnit);
        pace.Unit.Should().Be(unit);
    }

    [Theory]
    [InlineAutoData(-1)]
    [InlineAutoData(0)]
    public void Constructor_ShouldThrowForInvalidDuration(int minutes, DistanceUnits unit)
    {
        // Act 
        var act = () => new Pace(TimeSpan.FromMinutes(minutes), unit);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory, InlineAutoData]
    public void Constructor_ShouldThrowForInvalidUnit(double minutes)
    {
        // Act 
        var act = () => new Pace(TimeSpan.FromMinutes(minutes), (DistanceUnits)(-1));

        // Assert
        act.Should().Throw<ArgumentException>();
    }


    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        var pace = new Pace(TimeSpan.FromMinutes(5), DistanceUnits.Km);

        // Act
        string formattedString = pace.ToString();

        // Assert
        formattedString.Should().Be("5'00\" /Km");
    }

    [Theory, InlineAutoData]
    public void From_ShouldCreatePace(int distanceMagnitude)
    {
        // Arrange
        var factor = 5;
        var duration = TimeSpan.FromMinutes(distanceMagnitude * factor);
        var distance = new Distance(distanceMagnitude, DistanceUnits.Km);

        // Act
        var pace = Pace.From(duration, distance);

        // Assert
        pace.DurationPerUnit.Should().Be(TimeSpan.FromMinutes(factor));
        pace.Unit.Should().Be(DistanceUnits.Km);
    }
}
