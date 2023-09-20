using DevSquad.RunningRecords.Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace DevSquad.RunningRecords.Backend.Infrastructure.Context
{
    public class RunningContext : DbContext
    {
        public RunningContext(DbContextOptions<RunningContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RunningContext).Assembly);
        }

        public required DbSet<Record> RunningRecords { get; set; }
    }
}
