using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _041_Les_Car_API.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("28704f61-e4a7-4421-bfe1-60854f3c8643"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a3b17dce-2849-4b24-96a9-6ff319b58487"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a8e362b6-2369-4a51-9422-852b0ea1ebaa"));

            migrationBuilder.AddColumn<string>(
                name: "JwtToken",
                table: "Accounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Accounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("46b038f5-34df-4ecf-b1f5-c4a2505f9dd3"), "Blue", "Ford", "Fusion", 2019 },
                    { new Guid("5368480f-8321-461e-aa5d-ec0ab1c82915"), "Green", "Honda", "Civic", 2018 },
                    { new Guid("b242941c-043a-44c7-8dd1-754ef48a987f"), "Red", "Toyota", "Corolla", 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("46b038f5-34df-4ecf-b1f5-c4a2505f9dd3"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5368480f-8321-461e-aa5d-ec0ab1c82915"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b242941c-043a-44c7-8dd1-754ef48a987f"));

            migrationBuilder.DropColumn(
                name: "JwtToken",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("28704f61-e4a7-4421-bfe1-60854f3c8643"), "Red", "Toyota", "Corolla", 2020 },
                    { new Guid("a3b17dce-2849-4b24-96a9-6ff319b58487"), "Blue", "Ford", "Fusion", 2019 },
                    { new Guid("a8e362b6-2369-4a51-9422-852b0ea1ebaa"), "Green", "Honda", "Civic", 2018 }
                });
        }
    }
}
