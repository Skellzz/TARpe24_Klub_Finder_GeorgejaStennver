using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klub_Finder.Migrations
{
    /// <inheritdoc />
    public partial class AddKlubFilds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asukoht",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "Kirjeldus",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "KontaktEmail",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "Nimi",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "Pilt",
                table: "Klubid");

            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Klubid",
                newName: "ClubName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Klubid");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Klubid");

            migrationBuilder.RenameColumn(
                name: "ClubName",
                table: "Klubid",
                newName: "Telefon");

            migrationBuilder.AddColumn<string>(
                name: "Asukoht",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kirjeldus",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KontaktEmail",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nimi",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pilt",
                table: "Klubid",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
