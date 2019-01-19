using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class changedmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Meeting_MeetingId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_MeetingId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "ProjectsGrade",
                table: "Sale");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Rank",
                table: "Sale",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Sale",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Project",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "Rank",
                table: "Sale",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Sale",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeetingId",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectsGrade",
                table: "Sale",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_MeetingId",
                table: "Sale",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Meeting_MeetingId",
                table: "Sale",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
