using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class FixedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Employees_LecturesId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Employees_LecturesId",
                table: "LectureStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Lectures");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesId",
                table: "DepartmentLecture",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Lectures_LecturesId",
                table: "LectureStudent",
                column: "LecturesId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lectures_LecturesId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudent_Lectures_LecturesId",
                table: "LectureStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures");

            migrationBuilder.RenameTable(
                name: "Lectures",
                newName: "Employees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Employees_LecturesId",
                table: "DepartmentLecture",
                column: "LecturesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudent_Employees_LecturesId",
                table: "LectureStudent",
                column: "LecturesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
