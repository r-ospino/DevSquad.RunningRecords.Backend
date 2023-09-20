using DevSquad.RunningRecords.Backend.Domain;
using MediatR;
using Throw;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class DeleteARunHandler : IRequestHandler<DeleteARunCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRunningRecordRepository _repository;

    public DeleteARunHandler(IUnitOfWork unitOfWork, IRunningRecordRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public async Task Handle(DeleteARunCommand request, CancellationToken cancellationToken)
    {
        Guid.TryParse(request.Id, out var recordId).Throw().IfFalse();
        Record record = (await _repository.GetByIdAsync(recordId, cancellationToken)).ThrowIfNull();

        await _repository.DeleteAsync(record, cancellationToken);
        await _unitOfWork.CommitAsync();
    }
}
