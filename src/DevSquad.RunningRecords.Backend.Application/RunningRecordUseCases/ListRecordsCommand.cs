using MediatR;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases;

public class ListRecordsCommand : IStreamRequest<RecordDto>
{ }
