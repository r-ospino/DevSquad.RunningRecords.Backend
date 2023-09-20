using DevSquad.RunningRecords.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevSquad.RunningRecords.Backend.Infrastructure.Context
{
    internal class RunningRecordTypeConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.OwnsOne(record => record.Distance);
        }
    }
}
