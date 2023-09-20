using DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace DevSquad.RunningRecords.Backend.Api.RunningRecordsEndpoints;

[HttpGet("/api/run")]
[AllowAnonymous]
public class ListRecordsEndpoint : Endpoint<ListRecordsCommand, IAsyncEnumerable<RecordDto>>
{
    private readonly IMediator _mediator;

    public ListRecordsEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task HandleAsync(ListRecordsCommand req, CancellationToken ct)
    {
        await SendAsync(_mediator.CreateStream(req, ct), cancellation: ct);
    }
}
