using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheThrift.Data.Migrations
{
    public partial class AddedModifiedExpenseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Expensess");

            migrationBuilder.CreateTable(
                name: "ExpensesVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpensesType = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    DateOfExpenses = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesVM", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpensesVM");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Expensess",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
