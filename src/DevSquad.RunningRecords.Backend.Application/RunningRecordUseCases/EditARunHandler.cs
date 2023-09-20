using AutoMapper;
using DevSquad.RunningRecords.Backend.Domain;
using MediatR;
using Throw;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class EditARunHandler : IRequestHandler<EditARunCommand, RecordDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRunningRecordRepository _repository;
    private readonly IMapper _mapper;

    public EditARunHandler(IUnitOfWork unitOfWork, IRunningRecordRepository repository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RecordDto> Handle(EditARunCommand request, CancellationToken cancellationToken)
    {
        Guid.TryParse(request.Id, out var recordId).Throw().IfFalse();
        DateTime startDate = request.StartDate.ThrowIfNull();
        DateTime endDate = request.EndDate.ThrowIfNull().IfLessThanOrEqualTo(startDate);
        Enum.TryParse<DistanceUnits>(request.DistanceUnit, true, out var unit);

        Record record = (await _repository.GetByIdAsync(recordId, cancellationToken)).ThrowIfNull();
        record.Date = startDate;
        record.Duration = endDate.Subtract(startDate);
        record.Distance = new(request.DistanceMagnitude.ThrowIfNull(), unit);
        record.Steps = request.Steps.ThrowIfNull();

        await _unitOfWork.CommitAsync();

        return _mapper.Map<RecordDto>(record);
    }
}
