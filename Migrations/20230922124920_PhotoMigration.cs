using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowerWebsiteBackend.Migrations
{
    /// <inheritdoc />
    public partial class PhotoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName",
                table: "Rowers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFileName",
                table: "Rowers");
        }
    }
}
