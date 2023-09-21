using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowerWebsiteBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoUrlToRower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Rowers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Rowers");
        }
    }
}
