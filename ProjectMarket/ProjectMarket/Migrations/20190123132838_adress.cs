using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class adress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address",
                value: "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 5,
                column: "Address",
                value: "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 6,
                column: "Address",
                value: "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 7,
                column: "Address",
                value: "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 8,
                column: "Address",
                value: "המכללה למנהל בני ברק, רח' זאב ז'בוטינסקי, בני ברק, ישראל");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 5,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 6,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 7,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 8,
                column: "Address",
                value: null);
        }
    }
}
