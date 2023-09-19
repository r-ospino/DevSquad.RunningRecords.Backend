using DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;
using FastEndpoints;
using MediatR;

namespace DevSquad.RunningRecords.Backend.Api.RunningRecordsEndpoints;

public class RecordARunEndpoint : Endpoint<RecordARunCommand>
{
    private readonly IMediator _mediator;

    public RecordARunEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/api/run");
        AllowAnonymous();
    }

    public override Task HandleAsync(RecordARunCommand req, CancellationToken ct)
    {
        return _mediator.Send(req, ct);
    }
}
