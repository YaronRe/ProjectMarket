using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class pasten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcademicInstituteId", "Grade", "ProjectId", "Rank" },
                values: new object[] { null, null, 4, null });

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcademicInstituteId", "BuyerId", "Grade", "ProjectId", "Rank" },
                values: new object[] { 1, 1, 70, 5, 2 });

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AcademicInstituteId", "BuyerId", "Grade", "Rank" },
                values: new object[] { null, 3, null, null });

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AcademicInstituteId", "Grade", "ProjectId", "Rank" },
                values: new object[] { null, null, 3, null });

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProjectId",
                value: 5);

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "AcademicInstituteId", "AcceptedByBuyer", "AcceptedBySeller", "BuyerId", "Grade", "Price", "ProjectId", "Rank" },
                values: new object[,]
                {
                    { 7, 1, false, false, 3, 80, 0.0, 7, 4 },
                    { 8, null, false, false, 3, null, 0.0, 8, null },
                    { 9, 2, false, false, 5, 70, 0.0, 6, 3 },
                    { 10, 2, false, false, 5, 70, 0.0, 3, 3 },
                    { 11, 2, false, false, 5, 70, 0.0, 5, 3 },
                    { 12, 2, false, false, 6, 70, 0.0, 3, 3 },
                    { 13, 2, false, false, 6, 70, 0.0, 5, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcademicInstituteId", "Grade", "ProjectId", "Rank" },
                values: new object[] { 1, 70, 5, 2 });

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcademicInstituteId", "BuyerId", "Grade", "ProjectId", "Rank" },
                values: new object[] { null, 3, null, 6, null });

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AcademicInstituteId", "BuyerId", "Grade", "Rank" },
                values: new object[] { 2, 5, 70, 3 });

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AcademicInstituteId", "Grade", "ProjectId", "Rank" },
                values: new object[] { 1, 80, 7, 4 });

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProjectId",
                value: 8);
        }
    }
}
