using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apiBodega.Migrations
{
    /// <inheritdoc />
    public partial class IngresarUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "IdUser", "IsBlocked", "UserMail", "UserPassword" },
                values: new object[,]
                {
                    { 1, false, "rick1234@gmail.com", "admin4321" },
                    { 2, false, "cris1234@gmail.com", "admin1234" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "IdUser",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "usuarios",
                keyColumn: "IdUser",
                keyValue: 2);
        }
    }
}
