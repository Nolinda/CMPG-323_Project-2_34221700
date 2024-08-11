﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _34221700_Project2_CMPG323.Models;

#nullable disable

namespace _34221700_Project2_CMPG323.Migrations
{
    [DbContext(typeof(NWUDATABASEContext))]
    [Migration("20240811205924_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_34221700_Project2_CMPG323.Models.JobTelemetry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("BusinessFunction")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<DateTime>("EntryDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("ExcludeFromTimeSaving")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<string>("Geography")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int?>("HumanTime")
                        .HasColumnType("INT");

                    b.Property<string>("QueueID")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("StepDescription")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("UniqueReference")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("UniqueReferenceType")
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("ID");

                    b.ToTable("JobTelemetry", "Telemetry");
                });
#pragma warning restore 612, 618
        }
    }
}
