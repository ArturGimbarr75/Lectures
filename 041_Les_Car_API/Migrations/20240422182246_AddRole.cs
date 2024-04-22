using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _041_Les_Car_API.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Accounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { new Guid("06e9e5ce-a32e-42b6-aaf2-affea5128bc6"), "Blue", "Ford", "Fusion", 2019 },
                    { new Guid("07b45d66-b988-4337-b392-35e6498ab6a4"), "Red", "Toyota", "Corolla", 2020 },
                    { new Guid("8d4515f9-9c4f-4a03-9eb7-c637418ecd04"), "Green", "Honda", "Civic", 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("06e9e5ce-a32e-42b6-aaf2-affea5128bc6"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("07b45d66-b988-4337-b392-35e6498ab6a4"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("8d4515f9-9c4f-4a03-9eb7-c637418ecd04"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Accounts");

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
    }
}
