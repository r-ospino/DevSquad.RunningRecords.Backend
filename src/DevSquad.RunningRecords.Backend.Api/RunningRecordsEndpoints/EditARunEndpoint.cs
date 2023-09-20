using DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace DevSquad.RunningRecords.Backend.Api.RunningRecordsEndpoints;

[HttpPut("/api/run/{id}")]
[AllowAnonymous]
public class EditARunEndpoint : Endpoint<EditARunCommand, RecordDto>
{
    private readonly IMediator _mediator;

    public EditARunEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task HandleAsync(EditARunCommand req, CancellationToken ct)
    {
        var record = await _mediator.Send(req, ct);
        await SendAsync(record, cancellation: ct);
    }
}
