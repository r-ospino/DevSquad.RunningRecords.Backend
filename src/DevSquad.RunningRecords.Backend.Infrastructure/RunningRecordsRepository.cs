using DevSquad.RunningRecords.Backend.Domain;
using DevSquad.RunningRecords.Backend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DevSquad.RunningRecords.Backend.Infrastructure;

public class RunningRecordsRepository : IRunningRecordRepository
{
    private readonly RunningContext _context;

    public RunningRecordsRepository(RunningContext context) 
        => _context = context;

    public IAsyncEnumerable<Record> GetAllRecordsAsync(CancellationToken cancellationToken = default)
        => _context.RunningRecords.AsAsyncEnumerable();

    public Task<Record?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _context.RunningRecords.FirstOrDefaultAsync(record => record.Id == id, cancellationToken);

    public async Task AddAsync(Record entity, CancellationToken cancellationToken = default)
        => await _context.RunningRecords.AddAsync(entity, cancellationToken);

    public Task UpdateAsync(Record entity, CancellationToken cancellationToken = default)
        => Task.FromResult(_context.RunningRecords.Update(entity));

    public Task DeleteAsync(Record entity, CancellationToken cancellationToken = default)
        => Task.FromResult(_context.Remove(entity));
}
