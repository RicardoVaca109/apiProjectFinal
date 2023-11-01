using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiBodega.Migrations
{
    /// <inheritdoc />
    public partial class CambioDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "IdUser",
                keyValue: 1,
                column: "IsBlocked",
                value: false);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "IdUser",
                keyValue: 2,
                column: "IsBlocked",
                value: false);
        }
    }
}
