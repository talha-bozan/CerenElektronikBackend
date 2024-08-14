using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CerenElektronik_Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuotationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quotations",
                columns: new[] { "Id", "CountryCode", "Currency", "CustomerName", "DateCreated", "DeviceName", "Invoiced", "PassiveShieldingNeeded", "PerformerId", "PoFile", "PoOrPrePaymentRecievedForProduction", "PreparedBy", "QuotationAmount", "QuotationFile", "RFID", "RegionName", "RequestedBy", "RevisionStatus", "SentTo", "Status", "TaskCustomID", "TaskName" },
                values: new object[,]
                {
                    { 1, "US", "USD", "CustomerA", new DateTime(2024, 8, 14, 6, 9, 7, 506, DateTimeKind.Local).AddTicks(9743), "DeviceA", false, true, "P001", "poA.pdf", "Yes", "PreparerA", 1000f, "quotationA.pdf", "RFID001", "North", "RequesterA", 1, "customerA@example.com", 2, "T001", "Install new system" },
                    { 2, "FR", "EUR", "CustomerB", new DateTime(2024, 8, 14, 6, 9, 7, 508, DateTimeKind.Local).AddTicks(837), "DeviceB", true, false, "P002", "poB.pdf", "No", "PreparerB", 2000f, "quotationB.pdf", "RFID002", "South", "RequesterB", 0, "customerB@example.com", 0, "T002", "Upgrade existing system" },
                    { 3, "UK", "GBP", "CustomerC", new DateTime(2024, 8, 14, 6, 9, 7, 508, DateTimeKind.Local).AddTicks(860), "DeviceC", true, true, "P003", "poC.pdf", "Yes", "PreparerC", 1500f, "quotationC.pdf", "RFID003", "East", "RequesterC", 2, "customerC@example.com", 4, "T003", "System maintenance" },
                    { 4, "JP", "JPY", "CustomerD", new DateTime(2024, 8, 14, 6, 9, 7, 508, DateTimeKind.Local).AddTicks(865), "DeviceD", false, false, "P004", "poD.pdf", "No", "PreparerD", 2500f, "quotationD.pdf", "RFID004", "West", "RequesterD", 0, "customerD@example.com", 2, "T004", "Replace faulty component" },
                    { 5, "AU", "AUD", "CustomerE", new DateTime(2024, 8, 14, 6, 9, 7, 508, DateTimeKind.Local).AddTicks(870), "DeviceE", true, true, "P005", "poE.pdf", "Yes", "PreparerE", 1800f, "quotationE.pdf", "RFID005", "Central", "RequesterE", 1, "customerE@example.com", 0, "T005", "Install security update" },
                    { 6, "CA", "CAD", "CustomerF", new DateTime(2024, 8, 14, 6, 9, 7, 508, DateTimeKind.Local).AddTicks(873), "DeviceF", false, false, "P006", "poF.pdf", "No", "PreparerF", 2200f, "quotationF.pdf", "RFID006", "North", "RequesterF", 2, "customerF@example.com", 0, "T006", "Calibration of equipment" },
                    { 7, "US", "USD", "CustomerG", new DateTime(2024, 8, 14, 6, 9, 7, 508, DateTimeKind.Local).AddTicks(908), "DeviceG", true, true, "P007", "poG.pdf", "Yes", "PreparerG", 1300f, "quotationG.pdf", "RFID007", "East", "RequesterG", 1, "customerG@example.com", 3, "T007", "Conduct system audit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
