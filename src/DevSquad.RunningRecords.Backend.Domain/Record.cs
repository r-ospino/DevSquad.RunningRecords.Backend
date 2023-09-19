using Throw;

namespace DevSquad.RunningRecords.Backend.Domain;

public class Record
{
    public Record(DateTime date, TimeSpan duration, Distance distance, int steps)
    {
        Date = date;
        Duration = duration.Throw().IfNegativeOrZero();
        Distance = distance;
        Steps = steps;
        AveragePace = Pace.From(duration, distance);
        AverageSpeed = Speed.From(AveragePace);
    }

    public Guid Id { get; private set; }
 
    public DateTime Date { get; }

    public TimeSpan Duration { get; }

    public Distance Distance { get; }

    public int Steps { get; }

    public Pace AveragePace { get; }

    public Speed AverageSpeed { get; }
}
