using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class seedusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "MeetingLocationX",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "MeetingLocationY",
                table: "Sale");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptedByBuyer",
                table: "Sale",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptedBySeller",
                table: "Sale",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MeetingId",
                table: "Sale",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationLongitude = table.Column<double>(nullable: false),
                    LocationLatitude = table.Column<double>(nullable: false),
                    MeetingDate = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "EMail", "FirstName", "IsAdmin", "LastName", "Password", "UserName" },
                values: new object[] { 1, "aa@gmail.com", "AdminF", true, "AdminL", "12345678", "Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "EMail", "FirstName", "IsAdmin", "LastName", "Password", "UserName" },
                values: new object[] { 2, "aa@gmail.com", "UserF", false, "UserL", "12345678", "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_MeetingId",
                table: "Sale",
                column: "MeetingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Meeting_MeetingId",
                table: "Sale",
                column: "MeetingId",
                principalTable: "Meeting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Meeting_MeetingId",
                table: "Sale");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Sale_MeetingId",
                table: "Sale");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AcceptedByBuyer",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "AcceptedBySeller",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Sale");

            migrationBuilder.AddColumn<double>(
                name: "MeetingLocationX",
                table: "Sale",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MeetingLocationY",
                table: "Sale",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
