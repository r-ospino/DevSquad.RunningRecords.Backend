using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace DevSquad.RunningRecords.Backend.Domain.Tests;

public class RecordTests
{
    [Theory, InlineAutoData]
    public void Constructor_ShouldSetPropertiesCorrectly(int minutes, Distance distance, int steps)
    {
        // Arrange
        var date = DateTime.Now;
        var duration = TimeSpan.FromMinutes(minutes);

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
    public void Constructor_ShouldThrowForNegativeOrZeroDuration(int minutes, Distance distance, int steps)
    {
        // Arrange
        var date = DateTime.Now;
        var duration = TimeSpan.FromMinutes(minutes);

        // Act
        var act = () => new Record(date, duration, distance, steps);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory, InlineAutoData]
    public void Constructor_ShouldThrowForFutureDate(int days, int minutes, Distance distance, int steps)
    {
        // Arrange
        var date = DateTime.Now.AddDays(days);
        var duration = TimeSpan.FromMinutes(minutes);

        // Act
        var act = () => new Record(date, duration, distance, steps);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory, InlineAutoData]
    public void Steps_ShouldThrowForNegativeSteps(int minutes, Distance distance, int steps)
    {
        // Arrange
        var date = DateTime.Now;
        var duration = TimeSpan.FromMinutes(minutes);

        // Act
        var act = () => new Record(date, duration, distance, -steps);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
