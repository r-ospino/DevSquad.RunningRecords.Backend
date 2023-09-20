using MediatR;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class GetARunCommand : IRequest<RecordDto?>
{
    public string? Id { get; set; }
}
