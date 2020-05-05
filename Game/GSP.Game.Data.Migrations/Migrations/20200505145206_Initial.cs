using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSP.Game.Data.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeveloperStudios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByAccountId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedByAccountId = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    LogoUri = table.Column<string>(maxLength: 2048, nullable: false),
                    WebPageUri = table.Column<string>(maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByAccountId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedByAccountId = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByAccountId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedByAccountId = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    LogoUri = table.Column<string>(maxLength: 2048, nullable: false),
                    WebPageUri = table.Column<string>(maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedByAccountId = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedByAccountId = table.Column<long>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    GameDetails_Name = table.Column<string>(maxLength: 255, nullable: true),
                    GameDetails_AverageRating = table.Column<double>(nullable: true),
                    GameDetails_ReviewCount = table.Column<int>(nullable: true),
                    GameDetails_OrderCount = table.Column<int>(nullable: true),
                    GameDetails_Price = table.Column<float>(nullable: true),
                    GameDetails_Description = table.Column<string>(maxLength: 500, nullable: true),
                    GameDetails_ReleaseDate = table.Column<DateTime>(nullable: true),
                    GameDetails_AgeRestrictionSystem = table.Column<string>(maxLength: 50, nullable: true, defaultValue: "AllAges"),
                    GameDetails_IconUri = table.Column<string>(maxLength: 2048, nullable: true),
                    GameDetails_PhotoUri = table.Column<string>(maxLength: 2048, nullable: true),
                    GenreId = table.Column<long>(nullable: false),
                    DeveloperStudioId = table.Column<long>(nullable: false),
                    PublisherId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_DeveloperStudios_DeveloperStudioId",
                        column: x => x.DeveloperStudioId,
                        principalTable: "DeveloperStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    LinkUri = table.Column<string>(maxLength: 2048, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    GameId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameAttachments_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameAttachments_GameId",
                table: "GameAttachments",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperStudioId",
                table: "Games",
                column: "DeveloperStudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameAttachments");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "DeveloperStudios");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
