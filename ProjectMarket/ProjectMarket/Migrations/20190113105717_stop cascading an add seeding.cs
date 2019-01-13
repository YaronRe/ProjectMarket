using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class stopcascadinganaddseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AcademicInstitute_AcademicInstituteId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_FieldOfStudy_FieldOfStudyId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Project_ProjectId",
                table: "Sale");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Sale",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "AcademicInstituteId", "Address", "Description", "FieldOfStudyId", "IsDeleted", "LocationLatitude", "LocationLongitude", "Name", "OwnerId", "Price" },
                values: new object[] { 1, 1, null, "", 2, true, 0.0, 0.0, "DeletedOfUser", 2, 10.0 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "EMail", "FirstName", "IsAdmin", "IsDeleted", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 3, "user@gmail.com", "UserF", false, false, "UserL", "12345678", "Buyer" },
                    { 4, "user@gmail.com", "UserF", false, false, "UserL", "12345678", "Seller" },
                    { 5, "user@gmail.com", "UserF", false, false, "UserL", "12345678", "BuyerSeller" },
                    { 6, "user@gmail.com", "UserF", false, true, "UserL", "12345678", "deleted" },
                    { 7, "user@gmail.com", "UserF", false, false, "UserL", "12345678", "Grader" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "AcademicInstituteId", "Address", "Description", "FieldOfStudyId", "IsDeleted", "LocationLatitude", "LocationLongitude", "Name", "OwnerId", "Price" },
                values: new object[,]
                {
                    { 4, 1, null, "", 2, false, 0.0, 0.0, "NotSold", 4, 40.0 },
                    { 5, 1, null, "", 2, true, 0.0, 0.0, "SoldAndDeleted", 4, 50.0 },
                    { 6, 1, null, "", 2, false, 0.0, 0.0, "SoldMultiple", 4, 60.0 },
                    { 7, 1, null, "", 2, false, 0.0, 0.0, "Graded", 4, 60.0 },
                    { 8, 1, null, "", 2, false, 0.0, 0.0, "NotGraded", 4, 60.0 },
                    { 3, 1, null, "", 2, false, 0.0, 0.0, "Sold", 5, 30.0 },
                    { 2, 1, null, "", 2, true, 0.0, 0.0, "DeletedOfDelUser", 6, 20.0 }
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "AcademicInstituteId", "AcceptedByBuyer", "AcceptedBySeller", "BuyerId", "Grade", "Price", "ProjectId", "Rank" },
                values: new object[,]
                {
                    { 2, 1, false, false, 1, 70, 0.0, 5, 2 },
                    { 3, null, false, false, 3, null, 0.0, 6, null },
                    { 4, 2, false, false, 5, 70, 0.0, 6, 3 },
                    { 5, 1, false, false, 3, 80, 0.0, 7, 4 },
                    { 6, null, false, false, 3, null, 0.0, 8, null },
                    { 1, null, false, false, 1, null, 0.0, 3, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AcademicInstitute_AcademicInstituteId",
                table: "Project",
                column: "AcademicInstituteId",
                principalTable: "AcademicInstitute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_FieldOfStudy_FieldOfStudyId",
                table: "Project",
                column: "FieldOfStudyId",
                principalTable: "FieldOfStudy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Project_ProjectId",
                table: "Sale",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AcademicInstitute_AcademicInstituteId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_FieldOfStudy_FieldOfStudyId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Project_ProjectId",
                table: "Sale");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sale",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Sale",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AcademicInstitute_AcademicInstituteId",
                table: "Project",
                column: "AcademicInstituteId",
                principalTable: "AcademicInstitute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_FieldOfStudy_FieldOfStudyId",
                table: "Project",
                column: "FieldOfStudyId",
                principalTable: "FieldOfStudy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Project_ProjectId",
                table: "Sale",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
