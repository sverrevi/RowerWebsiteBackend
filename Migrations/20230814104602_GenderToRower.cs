using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowerWebsiteBackend.Migrations
{
    /// <inheritdoc />
    public partial class GenderToRower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowingClub",
                table: "Rowers");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Rowers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Rowers");

            migrationBuilder.AddColumn<string>(
                name: "RowingClub",
                table: "Rowers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
