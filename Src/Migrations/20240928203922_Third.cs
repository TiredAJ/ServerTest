using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerTest.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Superheroes",
                table: "Superheroes");

            migrationBuilder.RenameTable(
                name: "Superheroes",
                newName: "superheroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_superheroes",
                table: "superheroes",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_superheroes",
                table: "superheroes");

            migrationBuilder.RenameTable(
                name: "superheroes",
                newName: "Superheroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Superheroes",
                table: "Superheroes",
                column: "id");
        }
    }
}
