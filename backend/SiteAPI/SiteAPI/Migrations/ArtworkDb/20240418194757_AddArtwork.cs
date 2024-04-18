using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteAPI.Migrations.ArtworkDb
{
    /// <inheritdoc />
    public partial class AddArtwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearCreated = table.Column<int>(type: "INTEGER", nullable: false),
                    Series = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    ImageFilePath = table.Column<string>(type: "TEXT", nullable: false),
                    PeriodOfLifeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artworks");
        }
    }
}
