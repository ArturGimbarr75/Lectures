using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocupations_Orders_OrderId",
                table: "Ocupations");

            migrationBuilder.DropIndex(
                name: "IX_Ocupations_OrderId",
                table: "Ocupations");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Ocupations");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OcupationId",
                table: "Orders",
                column: "OcupationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Ocupations_OcupationId",
                table: "Orders",
                column: "OcupationId",
                principalTable: "Ocupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Ocupations_OcupationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OcupationId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Ocupations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ocupations_OrderId",
                table: "Ocupations",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocupations_Orders_OrderId",
                table: "Ocupations",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
