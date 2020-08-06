using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheThrift.Data.Migrations
{
    public partial class AddedUpdateToSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Salaries");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Salaries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LoanTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CustomerVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThriftPlan = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    OfficeAddress = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryVM", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerVM");

            migrationBuilder.DropTable(
                name: "SalaryVM");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Salaries");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Salaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LoanTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
