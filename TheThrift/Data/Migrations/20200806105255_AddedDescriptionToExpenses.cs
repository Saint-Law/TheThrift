using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheThrift.Data.Migrations
{
    public partial class AddedDescriptionToExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerVM");

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "Expensess",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "Expensess");

            migrationBuilder.CreateTable(
                name: "CustomerVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThriftPlan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerVM", x => x.Id);
                });
        }
    }
}
