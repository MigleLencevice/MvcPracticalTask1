using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcPracticalTask.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFilmModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Films",
                newName: "RunTimeMinutes");

            migrationBuilder.RenameColumn(
                name: "Director",
                table: "Films",
                newName: "Review");

            migrationBuilder.AddColumn<long>(
                name: "BoxOfficeDollars",
                table: "Films",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BudgetDollars",
                table: "Films",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "DirectorID",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FilmID",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OscarNominations",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OscarWins",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxOfficeDollars",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "BudgetDollars",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "FilmID",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "OscarNominations",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "OscarWins",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "RunTimeMinutes",
                table: "Films",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Review",
                table: "Films",
                newName: "Director");
        }
    }
}
