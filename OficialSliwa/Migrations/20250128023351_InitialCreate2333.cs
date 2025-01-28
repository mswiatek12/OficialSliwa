using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficialSliwa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "waalki",
                table: "statystyki",
                newName: "walki");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "walki",
                table: "statystyki",
                newName: "waalki");
        }
    }
}
