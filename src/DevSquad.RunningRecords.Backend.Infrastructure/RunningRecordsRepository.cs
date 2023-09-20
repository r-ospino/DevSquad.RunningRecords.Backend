using DevSquad.RunningRecords.Backend.Domain;
using DevSquad.RunningRecords.Backend.Infrastructure.Context;

namespace DevSquad.RunningRecords.Backend.Infrastructure;

public class RunningRecordsRepository : IRunningRecordRepository
{
    private readonly RunningContext _context;

    public RunningRecordsRepository(RunningContext context) 
        => _context = context;

    public IAsyncEnumerable<Record> GetAllRecordsAsync(CancellationToken cancellationToken = default)
        => _context.RunningRecords.AsAsyncEnumerable();

    public async Task AddAsync(Record entity, CancellationToken cancellationToken = default)
        => await _context.RunningRecords.AddAsync(entity, cancellationToken);
}
