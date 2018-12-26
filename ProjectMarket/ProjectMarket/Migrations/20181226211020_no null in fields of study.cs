using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMarket.Migrations
{
    public partial class nonullinfieldsofstudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AcademicInstitute_AcademicInstituteId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_FieldOfStudy_FieldOfStudyId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "FieldOfStudyId",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AcademicInstituteId",
                table: "Project",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AcademicInstitute_AcademicInstituteId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_FieldOfStudy_FieldOfStudyId",
                table: "Project");

            migrationBuilder.AlterColumn<int>(
                name: "FieldOfStudyId",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AcademicInstituteId",
                table: "Project",
                nullable: true,
                oldClrType: typeof(int));

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
        }
    }
}
