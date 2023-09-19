using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevSquad.RunningRecords.Backend.Domain;
using DevSquad.RunningRecords.Backend.Infrastructure.Context;

namespace DevSquad.RunningRecords.Backend.Infrastructure
{
    public class RunningRecordsRepository : IRunningRecordRepository
    {
        private readonly RunningContext _context;

        public RunningRecordsRepository(RunningContext context) 
            => _context = context;

        public async Task AddAsync(Record entity, CancellationToken cancellationToken = default)
        {
            await _context.RunningRecords.AddAsync(entity, cancellationToken);
        }
    }
}
