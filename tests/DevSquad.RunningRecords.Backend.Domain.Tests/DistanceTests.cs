using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace DevSquad.RunningRecords.Backend.Domain.Tests;

public class DistanceTests
{
    [Theory, InlineAutoData]
    public void Constructor_ShouldSetPropertiesCorrectly(double magnitude, DistanceUnits unit)
    {
        // Act
        var distance = new Distance(magnitude, unit);

        // Assert
        distance.Magnitude.Should().Be(magnitude);
        distance.Unit.Should().Be(unit);
    }

    [Theory]
    [InlineAutoData(-1)]
    [InlineAutoData(0)]
    public void Constructor_ShouldThrowForInvalidMagnitude(double magnitude, DistanceUnits unit)
    {
        // Act
        var act = () => new Distance(magnitude, unit);

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
        var distance = new Distance(10.5, DistanceUnits.Mi);

        // Act
        string formattedString = distance.ToString();

        // Assert
        formattedString.Should().Be("10.50 Mi");
    }
}
