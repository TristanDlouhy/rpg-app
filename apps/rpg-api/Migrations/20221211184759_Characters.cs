using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rpgapi.Migrations
{
    /// <inheritdoc />
    public partial class Characters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defence", "Health", "Intelligence", "Name", "Strength" },
                values: new object[,]
                {
                    { "354af967-b201-4749-baf4-faf113a24c06", 2, 20, 150, 15, "Amrier", 20 },
                    { "9f714da3-bdd8-4611-8b1e-db6fc81275f4", 8, 15, 100, 30, "Benag", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: "354af967-b201-4749-baf4-faf113a24c06");

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: "9f714da3-bdd8-4611-8b1e-db6fc81275f4");
        }
    }
}
