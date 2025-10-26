using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTourist.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderItemForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Arrangements_DestinationId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_DestinationId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_DestinationId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ArrangementId",
                table: "OrderItems",
                column: "ArrangementId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Arrangements_ArrangementId",
                table: "OrderItems",
                column: "ArrangementId",
                principalTable: "Arrangements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Arrangements_ArrangementId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ArrangementId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DestinationId",
                table: "OrderItems",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Arrangements_DestinationId",
                table: "OrderItems",
                column: "DestinationId",
                principalTable: "Arrangements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_DestinationId",
                table: "OrderItems",
                column: "DestinationId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
