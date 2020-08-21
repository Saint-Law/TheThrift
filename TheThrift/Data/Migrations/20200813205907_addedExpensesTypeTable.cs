using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheThrift.Data.Migrations
{
    public partial class addedExpensesTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanAllocations_LoanTypes_LeaveTypeId",
                table: "LoanAllocations");

            migrationBuilder.DropIndex(
                name: "IX_LoanAllocations_LeaveTypeId",
                table: "LoanAllocations");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "LoanAllocations");

            migrationBuilder.AddColumn<int>(
                name: "LoanTypeId",
                table: "LoanAllocations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClientVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(nullable: true),
                    ThriftPlan = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OfficeAddress = table.Column<string>(nullable: true),
                    ShopNo = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientVM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanAllocations_LoanTypeId",
                table: "LoanAllocations",
                column: "LoanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanAllocations_LoanTypes_LoanTypeId",
                table: "LoanAllocations",
                column: "LoanTypeId",
                principalTable: "LoanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanAllocations_LoanTypes_LoanTypeId",
                table: "LoanAllocations");

            migrationBuilder.DropTable(
                name: "ClientVM");

            migrationBuilder.DropIndex(
                name: "IX_LoanAllocations_LoanTypeId",
                table: "LoanAllocations");

            migrationBuilder.DropColumn(
                name: "LoanTypeId",
                table: "LoanAllocations");

            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "LoanAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LoanAllocations_LeaveTypeId",
                table: "LoanAllocations",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanAllocations_LoanTypes_LeaveTypeId",
                table: "LoanAllocations",
                column: "LeaveTypeId",
                principalTable: "LoanTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
