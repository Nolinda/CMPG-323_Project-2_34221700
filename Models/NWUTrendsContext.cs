﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _34221700_Project2_CMPG323.Models
{
    public partial class NWUTrendsContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public NWUTrendsContext(DbContextOptions<NWUTrendsContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<JobTelemetry> JobTelemetries { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("ConnStr");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTelemetry>()
                .HasOne(jt => jt.Project)
                .WithMany(p => p.JobTelemetries)
                .HasForeignKey(jt => jt.ProjectID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobTelemetry>()
                .HasOne(jt => jt.Client)
                .WithMany(p => p.JobTelemetries)
                .HasForeignKey(jt => jt.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client", "Config");

                entity.Property(e => e.ClientId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClientID");

                entity.Property(e => e.DateOnboarded).HasColumnType("datetime");
            });

            modelBuilder.Entity<JobTelemetry>(entity =>
            {
                entity.ToTable("JobTelemetry", "Telemetry");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AdditionalInfo).IsUnicode(false);
                entity.Property(e => e.BusinessFunction).IsUnicode(false);
                entity.Property(e => e.EntryDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.ExcludeFromTimeSaving).HasDefaultValue(false);
                entity.Property(e => e.Geography).IsUnicode(false);
                entity.Property(e => e.JobId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JobID");
                entity.Property(e => e.ProcessId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ProcessID");
                entity.Property(e => e.QueueId)
                    .IsUnicode(false)
                    .HasColumnName("QueueID");
                entity.Property(e => e.StepDescription).IsUnicode(false);
                entity.Property(e => e.UniqueReference).IsUnicode(false);
                entity.Property(e => e.UniqueReferenceType).IsUnicode(false);
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("Process", "Config");

                entity.Property(e => e.ProcessId)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("ProcessID");
                entity.Property(e => e.DateSubmitted)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.DefaultBusinessFunction)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValue("Unspecified");
                entity.Property(e => e.DefaultGeography)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValue("Global");
                entity.Property(e => e.Platform)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.ProcessConfigUrl)
                    .IsUnicode(false)
                    .HasColumnName("ProcessConfigURL");
                entity.Property(e => e.ProcessName).IsUnicode(false);
                entity.Property(e => e.ProcessType).IsUnicode(false);
                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
                entity.Property(e => e.ReportUrl)
                    .IsUnicode(false)
                    .HasColumnName("ReportURL");
                entity.Property(e => e.Submitter).IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project", "Config");

                entity.Property(e => e.ProjectId)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("ProjectID");
                entity.Property(e => e.ClientId).HasColumnName("ClientID");
                entity.Property(e => e.ProjectCreationDate)
                    .HasDefaultValueSql("(dateadd(hour,(2),getdate()))")
                    .HasColumnType("datetime");
                entity.Property(e => e.ProjectDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.ProjectStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
