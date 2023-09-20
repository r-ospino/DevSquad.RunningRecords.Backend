using System.Diagnostics.CodeAnalysis;
using Throw;

namespace DevSquad.RunningRecords.Backend.Domain;

public class Record
{
    private TimeSpan _duration;
    private int _steps;
    private DateTime _date;

    public Record()
    { }

    [SetsRequiredMembers]
    public Record(DateTime date, TimeSpan duration, Distance distance, int steps)
        => (Date, Duration, Distance, Steps) = (date, duration, distance, steps);

    public Guid Id { get; private set; }

    public required DateTime Date
    {
        get => _date;
        set => _date = value.Throw().IfGreaterThanOrEqualTo(DateTime.Now);
    }

    public required TimeSpan Duration
    {
        get => _duration;
        set => _duration = value.Throw().IfNegativeOrZero();
    }

    public required Distance Distance { get; set; }

    public required int Steps
    {
        get => _steps;
        set => _steps = value.Throw().IfNegativeOrZero();
    }

    public Pace AveragePace => Pace.From(Duration, Distance);

    public Speed AverageSpeed => Speed.From(AveragePace);
}
