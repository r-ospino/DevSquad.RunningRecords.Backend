using System.Diagnostics.CodeAnalysis;
using Throw;

namespace DevSquad.RunningRecords.Backend.Domain;

public record Pace(TimeSpan DurationPerUnit, DistanceUnits Unit)
{
    private static readonly TimeSpan _hour = TimeSpan.FromHours(1);

    [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "Validate constructor parameters")]
    private readonly bool _valid = DurationPerUnit.Throw().IfNegativeOrZero().IfGreaterThanOrEqualTo(_hour).IsValid()
        && Unit.Throw().IfOutOfRange().IsValid();
    
    public override string ToString() => $"{DurationPerUnit.Minutes:#0}'{DurationPerUnit.Seconds:00}\" /{Enum.GetName<DistanceUnits>(Unit)}";

    public static Pace From(TimeSpan duration, Distance distance)
        => new(duration.Divide(distance.Magnitude), distance.Unit);
}
