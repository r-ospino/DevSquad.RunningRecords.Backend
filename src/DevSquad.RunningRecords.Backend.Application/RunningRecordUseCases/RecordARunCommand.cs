using MediatR;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class RecordARunCommand : IRequest
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public double? DistanceMagnitude { get; set; }

    public string? DistanceUnit { get; set; }

    public int? Steps { get; set; }
}
