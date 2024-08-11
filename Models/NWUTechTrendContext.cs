using Microsoft.EntityFrameworkCore;

namespace _34221700_Project2_CMPG323.Models
{
    public class NWUDATABASEContext : DbContext
    {
        public NWUDATABASEContext(DbContextOptions<NWUDATABASEContext> options)
            : base(options)
        {
        }

        public DbSet<JobTelemetry> JobTelemetry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTelemetry>()
                .ToTable("JobTelemetry", "Telemetry")
                .HasKey(j => j.ID);

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.QueueID)
                .HasColumnType("VARCHAR(MAX)");

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.StepDescription)
                .HasColumnType("VARCHAR(MAX)");

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.HumanTime)
                .HasColumnType("INT");

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.UniqueReference)
                .HasColumnType("VARCHAR(MAX)");

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.UniqueReferenceType)
                .HasColumnType("VARCHAR(MAX)");

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.BusinessFunction)
                .HasColumnType("VARCHAR(MAX)");

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.Geography)
                .HasColumnType("VARCHAR(MAX)");

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.ExcludeFromTimeSaving)
                .HasColumnType("BIT")
                .HasDefaultValue(false);

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.AdditionalInfo)
                .HasColumnType("VARCHAR(MAX)");

            modelBuilder.Entity<JobTelemetry>()
                .Property(j => j.EntryDate)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("getdate()");
        }
    }
}
