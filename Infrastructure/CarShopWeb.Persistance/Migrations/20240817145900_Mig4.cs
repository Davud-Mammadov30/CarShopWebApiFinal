using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShopWeb.Persistence.Migrations
{
    public partial class Mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentsId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrdersId",
                table: "Payments",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrdersId",
                table: "Payments",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrdersId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrdersId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentsId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentsId",
                table: "Orders",
                column: "PaymentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentsId",
                table: "Orders",
                column: "PaymentsId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
