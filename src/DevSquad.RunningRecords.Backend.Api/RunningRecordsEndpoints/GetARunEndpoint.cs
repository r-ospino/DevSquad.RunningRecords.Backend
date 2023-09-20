using DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace DevSquad.RunningRecords.Backend.Api.RunningRecordsEndpoints;

[HttpGet("/api/run/{id}")]
[AllowAnonymous]
public class GetARunEndpoint : Endpoint<GetARunCommand, RecordDto?>
{
    private readonly IMediator _mediator;

    public GetARunEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async override Task HandleAsync(GetARunCommand req, CancellationToken ct)
    {
        var record = await _mediator.Send(req, ct);
        await SendAsync(record, cancellation: ct);
    }
}
