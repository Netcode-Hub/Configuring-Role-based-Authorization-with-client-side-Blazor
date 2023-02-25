using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JWTDemo.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "049e1039-ae07-472d-a2fc-fc9bebfe9d8d", "46626ef9-f025-4071-8110-c307bf473af9", "User", "USER" },
                    { "c4e51fb4-64e0-4045-8cb1-b5d86d16f245", "aa564067-ea38-4e3c-b699-15b50166d5c1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "049e1039-ae07-472d-a2fc-fc9bebfe9d8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4e51fb4-64e0-4045-8cb1-b5d86d16f245");
        }
    }
}
