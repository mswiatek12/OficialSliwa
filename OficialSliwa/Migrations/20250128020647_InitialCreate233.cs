using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficialSliwa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate233 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_statystyki_users_user_id",
                table: "statystyki");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "statystyki",
                newName: "osiągnięcia");

            migrationBuilder.RenameColumn(
                name: "Walki",
                table: "statystyki",
                newName: "waalki");

            migrationBuilder.RenameIndex(
                name: "IX_statystyki_user_id",
                table: "statystyki",
                newName: "IX_statystyki_osiągnięcia");

            migrationBuilder.AddForeignKey(
                name: "FK_statystyki_users_osiągnięcia",
                table: "statystyki",
                column: "osiągnięcia",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_statystyki_users_osiągnięcia",
                table: "statystyki");

            migrationBuilder.RenameColumn(
                name: "waalki",
                table: "statystyki",
                newName: "Walki");

            migrationBuilder.RenameColumn(
                name: "osiągnięcia",
                table: "statystyki",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_statystyki_osiągnięcia",
                table: "statystyki",
                newName: "IX_statystyki_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_statystyki_users_user_id",
                table: "statystyki",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
