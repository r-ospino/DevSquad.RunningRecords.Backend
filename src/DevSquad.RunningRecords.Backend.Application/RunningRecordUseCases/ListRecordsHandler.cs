using System.Runtime.CompilerServices;
using AutoMapper;
using DevSquad.RunningRecords.Backend.Domain;
using MediatR;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases
{
    public class ListRecordsHandler : IStreamRequestHandler<ListRecordsCommand, RecordDto>
    {
        private readonly IRunningRecordRepository _repository;
        private readonly IMapper _mapper;
        
        public ListRecordsHandler(IRunningRecordRepository repository,  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async IAsyncEnumerable<RecordDto> Handle(ListRecordsCommand request, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var records = _repository.GetAllRecordsAsync(cancellationToken);

            await foreach (var record in records)
            {
                yield return _mapper.Map<RecordDto>(record);
            }
        }
    }
}
