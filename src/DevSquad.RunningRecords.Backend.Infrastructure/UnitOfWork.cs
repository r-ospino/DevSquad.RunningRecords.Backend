using DevSquad.RunningRecords.Backend.Domain;
using DevSquad.RunningRecords.Backend.Infrastructure.Context;

namespace DevSquad.RunningRecords.Backend.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly RunningContext _context;

    public UnitOfWork(RunningContext context)
    {
        _context = context;
    }

    public Task CommitAsync()
        => _context.SaveChangesAsync();

    public Task RollbackAsync()
        => throw new NotImplementedException();
}
