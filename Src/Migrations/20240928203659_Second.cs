using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerTest.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Place",
                table: "Superheroes",
                newName: "place");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Superheroes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Superheroes",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Superheroes",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "place",
                table: "Superheroes",
                newName: "Place");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Superheroes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Superheroes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Superheroes",
                newName: "ID");
        }
    }
}
