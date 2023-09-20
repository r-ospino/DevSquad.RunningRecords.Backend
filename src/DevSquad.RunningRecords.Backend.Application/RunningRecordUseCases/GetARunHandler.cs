using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevSquad.RunningRecords.Backend.Domain;
using MediatR;
using Throw;

namespace DevSquad.RunningRecords.Backend.Application.RunningRecordUseCases
{
    public class GetARunHandler : IRequestHandler<GetARunCommand, RecordDto?>
    {
        private readonly IRunningRecordRepository _repository;
        private readonly IMapper _mapper;

        public GetARunHandler(IRunningRecordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RecordDto?> Handle(GetARunCommand request, CancellationToken cancellationToken)
        {
            Guid.TryParse(request.Id, out var recordId).Throw().IfFalse();
            Record? record = await _repository.GetByIdAsync(recordId, cancellationToken);
            return _mapper.Map<RecordDto>(record);
        }
    }
}
