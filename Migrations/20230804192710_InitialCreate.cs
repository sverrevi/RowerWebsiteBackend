using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowerWebsiteBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowingClub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RowingClubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClubLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClubWebsiteURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowingClubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RowerRowingClub",
                columns: table => new
                {
                    MembersId = table.Column<int>(type: "int", nullable: false),
                    RowingClubsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowerRowingClub", x => new { x.MembersId, x.RowingClubsId });
                    table.ForeignKey(
                        name: "FK_RowerRowingClub_Rowers_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Rowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RowerRowingClub_RowingClubs_RowingClubsId",
                        column: x => x.RowingClubsId,
                        principalTable: "RowingClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RowerRowingClub_RowingClubsId",
                table: "RowerRowingClub",
                column: "RowingClubsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RowerRowingClub");

            migrationBuilder.DropTable(
                name: "Rowers");

            migrationBuilder.DropTable(
                name: "RowingClubs");
        }
    }
}
