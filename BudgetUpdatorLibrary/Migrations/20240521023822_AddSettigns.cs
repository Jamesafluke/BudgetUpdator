using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetUpdatorLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddSettigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaxAmount = table.Column<double>(type: "REAL", nullable: false),
                    DeleteCsvsAfterUpdating = table.Column<bool>(type: "INTEGER", nullable: false),
                    SelectPreviousMonth = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
