using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class pasten2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProjectId",
                value: 6);

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "AcademicInstituteId", "AcceptedByBuyer", "AcceptedBySeller", "BuyerId", "Grade", "Price", "ProjectId", "Rank" },
                values: new object[] { 14, 2, false, false, 6, 70, 0.0, 6, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProjectId",
                value: 5);
        }
    }
}
