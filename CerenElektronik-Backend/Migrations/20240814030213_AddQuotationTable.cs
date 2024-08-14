using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CerenElektronik_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddQuotationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskCustomID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerformerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevisionStatus = table.Column<int>(type: "int", nullable: true),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationAmount = table.Column<float>(type: "real", nullable: true),
                    SentTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuotationFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoOrPrePaymentRecievedForProduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Invoiced = table.Column<bool>(type: "bit", nullable: true),
                    PassiveShieldingNeeded = table.Column<bool>(type: "bit", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotations");
        }
    }
}
