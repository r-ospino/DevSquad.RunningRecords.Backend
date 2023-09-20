namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class RecordDto
{
    public string? Id { get; set; }

    public DateTime Date { get; set; }

    public string? Duration { get; set; }

    public string? Distance { get; set; }

    public int Steps { get; set; }

    public string? AveragePace { get; set; }

    public string? AverageSpeed { get; set; }
}
