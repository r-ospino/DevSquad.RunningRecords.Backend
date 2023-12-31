﻿using DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace DevSquad.RunningRecords.Backend.Api.RunningRecordsEndpoints;

[HttpPost("/api/run")]
[AllowAnonymous]
public class RecordARunEndpoint : Endpoint<RecordARunCommand>
{
    private readonly IMediator _mediator;

    public RecordARunEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override Task HandleAsync(RecordARunCommand req, CancellationToken ct)
    {
        return _mediator.Send(req, ct);
    }
}
