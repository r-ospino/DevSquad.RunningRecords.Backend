using DevSquad.RunningRecords.Backend.Domain;
using MediatR;
using Throw;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class RecordARunHandler : IRequestHandler<RecordARunCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRunningRecordRepository _repository;

    public RecordARunHandler(IUnitOfWork unitOfWork, IRunningRecordRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task Handle(RecordARunCommand request, CancellationToken cancellationToken)
    {
        var startDate = request.StartDate.ThrowIfNull();
        var endDate = request.EndDate.ThrowIfNull().IfLessThanOrEqualTo(startDate);
        var steps = request.Steps.ThrowIfNull();
        var distanceMagnitude = request.DistanceMagnitude.ThrowIfNull();

        TimeSpan duration = endDate.Value.Subtract(startDate);
        Enum.TryParse<DistanceUnits>(request.DistanceUnit, true, out var unit);
        
        Distance distance = new(distanceMagnitude, unit);
        Record activity = new(startDate, duration, distance, steps);
        await _repository.AddAsync(activity, cancellationToken);

        await _unitOfWork.CommitAsync();
    }
}
