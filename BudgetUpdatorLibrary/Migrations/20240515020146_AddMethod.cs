using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetUpdatorLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Method",
                table: "BudgetItems",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "BudgetItems");
        }
    }
}
