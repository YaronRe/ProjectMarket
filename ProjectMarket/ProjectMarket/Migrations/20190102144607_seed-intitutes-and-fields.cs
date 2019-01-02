using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class seedintitutesandfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AcademicInstitute",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "המכללה למנהל" },
                    { 2, "מכון לב" }
                });

            migrationBuilder.InsertData(
                table: "FieldOfStudy",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "מדעי המחשב" },
                    { 2, "כלכלה" },
                    { 3, "פיזיקה" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "EMail",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "EMail",
                value: "user@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AcademicInstitute",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AcademicInstitute",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FieldOfStudy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FieldOfStudy",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FieldOfStudy",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "EMail",
                value: "aa@gmail.com");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "EMail",
                value: "aa@gmail.com");
        }
    }
}
