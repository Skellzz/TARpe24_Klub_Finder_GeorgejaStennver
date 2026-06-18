using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klub_Finder.Migrations
{
    /// <inheritdoc />
    public partial class AddKlubFiltersAndReactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Klubid",
                table: "Klubid");

            migrationBuilder.RenameTable(
                name: "Klubid",
                newName: "Klubi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klubi",
                table: "Klubi",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "KlubReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KlubId = table.Column<int>(type: "int", nullable: false),
                    ReactionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlubReactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KlubReactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Klubi",
                table: "Klubi");

            migrationBuilder.RenameTable(
                name: "Klubi",
                newName: "Klubid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Klubid",
                table: "Klubid",
                column: "Id");
        }
    }
}
