using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace DevSquad.RunningRecords.Backend.Domain.Tests;

public class RecordTests
{
    [Theory, InlineAutoData]
    public void Constructor_ShouldSetPropertiesCorrectly(DateTime date, TimeSpan duration, Distance distance, int steps)
    {
        // Act
        var record = new Record(date, duration, distance, steps);

        // Assert
        record.Date.Should().Be(date);
        record.Duration.Should().Be(duration);
        record.Distance.Should().Be(distance);
        record.Steps.Should().Be(steps);
        record.AveragePace.Should().NotBeNull();
        record.AverageSpeed.Should().NotBeNull();
    }

    [Theory]
    [InlineAutoData(0)]
    [InlineAutoData(-1)]
    public void Constructor_ShouldThrowForInvalidDuration(int minutes, DateTime date, Distance distance, int steps)
    {
        // Arrange
        var duration = TimeSpan.FromMinutes(minutes);

        // Act
        var act = () => new Record(date, duration, distance, steps);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
