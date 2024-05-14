using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteExam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JwtToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JwtToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");
        }
    }
}
