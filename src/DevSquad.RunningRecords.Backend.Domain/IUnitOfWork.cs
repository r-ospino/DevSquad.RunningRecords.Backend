namespace DevSquad.RunningRecords.Backend.Domain;

public interface IUnitOfWork
{
    Task CommitAsync();

    Task RollbackAsync();
}
