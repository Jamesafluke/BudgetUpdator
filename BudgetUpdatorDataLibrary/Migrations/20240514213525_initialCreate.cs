using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetUpdatorDataLibrary.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "budgetItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Item = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExportedToBudget = table.Column<bool>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ManuallyAdded = table.Column<bool>(type: "INTEGER", nullable: false),
                    BudgetItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budgetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_budgetItems_budgetItems_BudgetItemId",
                        column: x => x.BudgetItemId,
                        principalTable: "budgetItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_budgetItems_BudgetItemId",
                table: "budgetItems",
                column: "BudgetItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budgetItems");
        }
    }
}
