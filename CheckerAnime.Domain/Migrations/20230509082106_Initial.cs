using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckerAnime.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoiceStudios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoiceAnimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    VoiceStudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceAnimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoiceAnimes_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoiceAnimes_VoiceStudios_VoiceStudioId",
                        column: x => x.VoiceStudioId,
                        principalTable: "VoiceStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoiceAnimeId = table.Column<int>(type: "int", nullable: false),
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_VoiceAnimes_VoiceAnimeId",
                        column: x => x.VoiceAnimeId,
                        principalTable: "VoiceAnimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_VoiceAnimeId",
                table: "Notifications",
                column: "VoiceAnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoiceAnimes_AnimeId",
                table: "VoiceAnimes",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoiceAnimes_VoiceStudioId",
                table: "VoiceAnimes",
                column: "VoiceStudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "VoiceAnimes");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "VoiceStudios");
        }
    }
}
