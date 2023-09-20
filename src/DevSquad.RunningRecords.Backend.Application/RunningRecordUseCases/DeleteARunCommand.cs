using MediatR;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class DeleteARunCommand : IRequest
{
    public string? Id { get; set; }
}
