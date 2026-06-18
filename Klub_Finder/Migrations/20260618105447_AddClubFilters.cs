using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klub_Finder.Migrations
{
    /// <inheritdoc />
    public partial class AddClubFilters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DistanceKm",
                table: "Klubid",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasLiveMusic",
                table: "Klubid",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Is18Plus",
                table: "Klubid",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MusicType",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "DistanceKm",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "HasLiveMusic",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "Is18Plus",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "MusicType",
                table: "Klubid");
        }
    }
}
