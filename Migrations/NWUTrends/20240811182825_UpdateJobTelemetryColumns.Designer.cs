﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _34221700_Project2_CMPG323.Models;

#nullable disable

namespace _34221700_Project2_CMPG323.Migrations.NWUTrends
{
    [DbContext(typeof(NWUTrendsContext))]
    [Migration("20240811182825_UpdateJobTelemetryColumns")]
    partial class UpdateJobTelemetryColumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.Client", b =>
                {
                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClientID");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOnboarded")
                        .HasColumnType("datetime");

                    b.Property<string>("PrimaryContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Client", "Config");
                });

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.JobTelemetry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("BusinessFunction")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<bool?>("ExcludeFromTimeSaving")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Geography")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("HumanTime")
                        .HasColumnType("int");

                    b.Property<string>("JobId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("JobID");

                    b.Property<string>("ProcessId")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ProcessID");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QueueId")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("QueueID");

                    b.Property<string>("StepDescription")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UniqueReference")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UniqueReferenceType")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProjectID");

                    b.ToTable("JobTelemetry", "Telemetry");
                });

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.Process", b =>
                {
                    b.Property<Guid>("ProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProcessID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("DateSubmitted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("DefaultBusinessFunction")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("Unspecified");

                    b.Property<string>("DefaultGeography")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasDefaultValue("Global");

                    b.Property<bool>("IsFramework")
                        .HasColumnType("bit");

                    b.Property<string>("Platform")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProcessConfigUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ProcessConfigURL");

                    b.Property<string>("ProcessName")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ProcessType")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProjectID");

                    b.Property<string>("ReportUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("ReportURL");

                    b.Property<bool>("RequiresDefaultConfig")
                        .HasColumnType("bit");

                    b.Property<string>("Submitter")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("ProcessId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Process", "Config");
                });

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProjectID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClientID");

                    b.Property<DateTime?>("ProjectCreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(dateadd(hour,(2),getdate()))");

                    b.Property<string>("ProjectDescription")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProjectStatus")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ProjectId");

                    b.HasIndex("ClientId");

                    b.ToTable("Project", "Config");
                });

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.JobTelemetry", b =>
                {
                    b.HasOne("_34221700_Project2_CMPG323.Models.Client", "Client")
                        .WithMany("JobTelemetries")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("_34221700_Project2_CMPG323.Models.Project", "Project")
                        .WithMany("JobTelemetries")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.Process", b =>
                {
                    b.HasOne("_34221700_Project2_CMPG323.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.Project", b =>
                {
                    b.HasOne("_34221700_Project2_CMPG323.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.Client", b =>
                {
                    b.Navigation("JobTelemetries");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.Project", b =>
                {
                    b.Navigation("JobTelemetries");
                });
#pragma warning restore 612, 618
        }
    }
}