namespace DevSquad.RunningRecords.Backend.Domain;

public interface IRunningRecordRepository
{
    Task AddAsync(Record entity, CancellationToken cancellationToken = default);
}
