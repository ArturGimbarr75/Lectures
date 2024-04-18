using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _041_Les_Car_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Accounts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "JwtToken",
                table: "Accounts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("11bb9702-f64c-4e69-a8f0-3d6b0ff8f206"), "Red", "Toyota", "Corolla", 2020 },
                    { new Guid("788fb6a4-0a20-492e-8a6b-96aafddd9082"), "Green", "Honda", "Civic", 2018 },
                    { new Guid("93f8011a-868f-415b-b1c4-be06fab4d484"), "Blue", "Ford", "Fusion", 2019 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("11bb9702-f64c-4e69-a8f0-3d6b0ff8f206"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("788fb6a4-0a20-492e-8a6b-96aafddd9082"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("93f8011a-868f-415b-b1c4-be06fab4d484"));

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Accounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JwtToken",
                table: "Accounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

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
    }
}
