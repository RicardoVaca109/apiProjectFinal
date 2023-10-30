using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apiBodega.Migrations
{
    /// <inheritdoc />
    public partial class NuevosDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "products",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "empresas",
                columns: new[] { "EmpresaID", "NombreEmpresa", "Resumen" },
                values: new object[,]
                {
                    { 1, "Supermaxi", "Empresa de viveres y consumo" },
                    { 2, "ElectronicaEc", "Empresa que vende componentes eléctricos" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductoId", "CtdenStock", "Descripcion", "Nombre", "Precio", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 300, "Cloro para uso doméstico", "Clorox", 5.9900000000000002, 1 },
                    { 2, 89, "Detergente en crema ideal para el lavado manual de vajilla", "Lava", 6.9900000000000002, 1 },
                    { 3, 4, "Brochas para limpieza de componentes eléctricos", " Kit Brochas antiestáticas", 3.5, 2 },
                    { 4, 34, "Alcohol Isopropilico al 90%", "Alcohol Isopropilico", 6.7999999999999998, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "empresas",
                keyColumn: "EmpresaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "empresas",
                keyColumn: "EmpresaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductoId",
                keyValue: 4);

            migrationBuilder.AlterColumn<float>(
                name: "Precio",
                table: "products",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
