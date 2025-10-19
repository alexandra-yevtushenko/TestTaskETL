using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskETL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TpepPickupDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TpepDropoffDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassengerCount = table.Column<int>(type: "int", nullable: true),
                    TripDistance = table.Column<float>(type: "real", nullable: false),
                    StoreAndFwdFlag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PULocationId = table.Column<int>(type: "int", nullable: false),
                    DOLocationId = table.Column<int>(type: "int", nullable: false),
                    FareAmount = table.Column<float>(type: "real", nullable: false),
                    TipAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SampleData_FareAmount",
                table: "SampleData",
                column: "FareAmount");

            migrationBuilder.CreateIndex(
                name: "IX_SampleData_PULocationId",
                table: "SampleData",
                column: "PULocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleData");
        }
    }
}
