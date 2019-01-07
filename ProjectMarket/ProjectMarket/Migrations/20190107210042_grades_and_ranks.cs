using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class grades_and_ranks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Project_ProjectId",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Sale",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Sale",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Project_ProjectId",
                table: "Sale",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Project_ProjectId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Sale",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Project_ProjectId",
                table: "Sale",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
