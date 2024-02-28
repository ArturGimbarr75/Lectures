using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _036_Les.Migrations
{
    /// <inheritdoc />
    public partial class AddTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_MainFolders_FolderId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_FolderId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "MainFolderId",
                table: "Files",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTag",
                columns: table => new
                {
                    FilesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTag", x => new { x.FilesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_FileTag_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_MainFolderId",
                table: "Files",
                column: "MainFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_FileTag_TagsId",
                table: "FileTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_MainFolders_MainFolderId",
                table: "Files",
                column: "MainFolderId",
                principalTable: "MainFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_MainFolders_MainFolderId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "FileTag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Files_MainFolderId",
                table: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "MainFolderId",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_MainFolders_FolderId",
                table: "Files",
                column: "FolderId",
                principalTable: "MainFolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
