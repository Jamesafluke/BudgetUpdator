using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetUpdatorLibrary.Migrations
{
    /// <inheritdoc />
    public partial class removeUnusedFieldsFromBudgetItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "BudgetItems");

            migrationBuilder.DropColumn(
                name: "ExportedToBudget",
                table: "BudgetItems");

            migrationBuilder.DropColumn(
                name: "ManuallyAdded",
                table: "BudgetItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "BudgetItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExportedToBudget",
                table: "BudgetItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ManuallyAdded",
                table: "BudgetItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
