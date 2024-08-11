using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _34221700_Project2_CMPG323.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Telemetry");

            migrationBuilder.CreateTable(
                name: "JobTelemetry",
                schema: "Telemetry",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueueID = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    StepDescription = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    HumanTime = table.Column<int>(type: "INT", nullable: true),
                    UniqueReference = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    UniqueReferenceType = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    BusinessFunction = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    Geography = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    ExcludeFromTimeSaving = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    AdditionalInfo = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTelemetry", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTelemetry",
                schema: "Telemetry");
        }
    }
}
