using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace DevSquad.RunningRecords.Backend.Domain.Tests;

public class SpeedTests
{
    [Fact]
    public void Constructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var magnitude = 10.0;
        var unit = DistanceUnits.Km;

        // Act
        var speed = new Speed(magnitude, unit);

        // Assert
        speed.Magnitud.Should().Be(magnitude);
        speed.Unit.Should().Be(unit);
    }

    [Theory]
    [InlineAutoData(-1)]
    [InlineAutoData(0)]
    public void Constructor_ShouldThrowForInvalidMagnitude(double magnitude, DistanceUnits unit)
    {
        // Act
        var act = () => new Speed(magnitude, unit);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory, InlineAutoData]
    public void Constructor_ShouldThrowForInvalidUnit(double magnitude)
    {
        // Act 
        var act = () => new Distance(magnitude, (DistanceUnits)(-1));

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        var speed = new Speed(12.345, DistanceUnits.Mi);

        // Act
        string formattedString = speed.ToString();

        // Assert
        formattedString.Should().Be("12.35 Mi/h");
    }

    [Theory, InlineAutoData]
    public void From_DurationAndDistance_ShouldCalculateSpeed(Distance distance)
    {
        // Arrange
        var duration = TimeSpan.FromHours(1);

        // Act
        var speed = Speed.From(duration, distance);

        // Assert
        speed.Magnitud.Should().Be(distance.Magnitude);
        speed.Unit.Should().Be(distance.Unit);
    }

    [Fact]
    public void From_Pace_ShouldCalculateSpeed()
    {
        // Arrange
        var pace = new Pace(TimeSpan.FromMinutes(5), DistanceUnits.Km);

        // Act
        var speed = Speed.From(pace);

        // Assert
        speed.Magnitud.Should().Be(12.0); // 60 minutes / 5 minutes/kilometer = 12 kilometers/hour
        speed.Unit.Should().Be(DistanceUnits.Km);
    }
}
