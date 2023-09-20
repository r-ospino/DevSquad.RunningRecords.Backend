namespace DevSquad.RunningRecords.Backend.Domain;

public interface IRunningRecordRepository
{
    IAsyncEnumerable<Record> GetAllRecordsAsync(CancellationToken cancellationToken = default);

    Task<Record?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(Record entity, CancellationToken cancellationToken = default);

    Task UpdateAsync(Record entity, CancellationToken cancellationToken = default);

    Task DeleteAsync(Record entity, CancellationToken cancellationToken = default);
}
