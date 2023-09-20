using DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace DevSquad.RunningRecords.Backend.Api.RunningRecordsEndpoints;

[HttpDelete("/api/run/{id}")]
[AllowAnonymous]
public class DeleteARunEndpoint : Endpoint<DeleteARunCommand, RecordDto>
{
    private readonly IMediator _mediator;

    public DeleteARunEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task HandleAsync(DeleteARunCommand req, CancellationToken ct)
    {
        await _mediator.Send(req, ct);
        await SendNoContentAsync(ct);
    }
}
