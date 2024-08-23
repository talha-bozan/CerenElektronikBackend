using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CerenElektronik_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePerformerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "QuotationAmount",
                table: "Performers");

            migrationBuilder.RenameColumn(
                name: "TaskCustomID",
                table: "Performers",
                newName: "ThirdInstaller");

            migrationBuilder.RenameColumn(
                name: "RequestedBy",
                table: "Performers",
                newName: "SecondInstaller");

            migrationBuilder.RenameColumn(
                name: "RegionName",
                table: "Performers",
                newName: "SafetyDocuments");

            migrationBuilder.RenameColumn(
                name: "RFID",
                table: "Performers",
                newName: "RfTestHandOverD");

            migrationBuilder.RenameColumn(
                name: "PreparedBy",
                table: "Performers",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "PerformerId",
                table: "Performers",
                newName: "QuotationNo");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Performers",
                newName: "ProjectManager");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Performers",
                newName: "ProgressDailyReport");

            migrationBuilder.AddColumn<string>(
                name: "ActionRequired",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Assignee",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "Performers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Performers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FourthInstaller",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Iatd1",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceId",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Invoiced",
                table: "Performers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeadInstaller",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pictures",
                table: "Performers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Performers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Performers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TimeLogged",
                table: "Performers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TimeLoggedRolledUp",
                table: "Performers",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 11, 19, 44, 530, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 11, 19, 44, 531, DateTimeKind.Local).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 11, 19, 44, 531, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 11, 19, 44, 531, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 11, 19, 44, 531, DateTimeKind.Local).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 11, 19, 44, 531, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 11, 19, 44, 531, DateTimeKind.Local).AddTicks(2501));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionRequired",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "FourthInstaller",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Iatd1",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Invoiced",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "LeadInstaller",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Pictures",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "TimeLogged",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "TimeLoggedRolledUp",
                table: "Performers");

            migrationBuilder.RenameColumn(
                name: "ThirdInstaller",
                table: "Performers",
                newName: "TaskCustomID");

            migrationBuilder.RenameColumn(
                name: "SecondInstaller",
                table: "Performers",
                newName: "RequestedBy");

            migrationBuilder.RenameColumn(
                name: "SafetyDocuments",
                table: "Performers",
                newName: "RegionName");

            migrationBuilder.RenameColumn(
                name: "RfTestHandOverD",
                table: "Performers",
                newName: "RFID");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Performers",
                newName: "PreparedBy");

            migrationBuilder.RenameColumn(
                name: "QuotationNo",
                table: "Performers",
                newName: "PerformerId");

            migrationBuilder.RenameColumn(
                name: "ProjectManager",
                table: "Performers",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "ProgressDailyReport",
                table: "Performers",
                newName: "Currency");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Performers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "QuotationAmount",
                table: "Performers",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 10, 57, 51, 373, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 10, 57, 51, 375, DateTimeKind.Local).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 10, 57, 51, 375, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 10, 57, 51, 375, DateTimeKind.Local).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 10, 57, 51, 375, DateTimeKind.Local).AddTicks(242));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 10, 57, 51, 375, DateTimeKind.Local).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2024, 8, 23, 10, 57, 51, 375, DateTimeKind.Local).AddTicks(249));
        }
    }
}
