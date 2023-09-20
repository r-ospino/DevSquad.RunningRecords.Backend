namespace DevSquad.RunningRecords.Backend.Domain;

public interface IRunningRecordRepository
{
    IAsyncEnumerable<Record> GetAllRecordsAsync(CancellationToken cancellationToken = default);

    Task AddAsync(Record entity, CancellationToken cancellationToken = default);
}
