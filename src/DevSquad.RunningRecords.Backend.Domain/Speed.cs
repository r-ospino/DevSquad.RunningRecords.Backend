using System.Diagnostics.CodeAnalysis;
using Throw;

namespace DevSquad.RunningRecords.Backend.Domain;

public record Speed(double Magnitud, DistanceUnits Unit)
{
    private const int minutesPerHour = 60;

    [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "Validate constructor parameters")]
    private readonly bool _valid = Magnitud.Throw().IfNegativeOrZero().IsValid()
        && Unit.Throw().IfOutOfRange().IsValid();

    public override string ToString() 
        => $"{Magnitud:#.00} {Enum.GetName<DistanceUnits>(Unit)}/h";

    public static Speed From(TimeSpan duration, Distance distance) 
        => new(distance.Magnitude / duration.TotalHours, distance.Unit);

    public static Speed From(Pace pace)
        => new(minutesPerHour / pace.DurationPerUnit.TotalMinutes, pace.Unit);
}
