using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShopWeb.Persistence.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentsId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountDetailId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactTypeId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountDetailId",
                table: "ContactType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountDetailId",
                table: "AccountDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentsId",
                table: "Orders",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountDetailId",
                table: "Customers",
                column: "AccountDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactTypeId",
                table: "Customers",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactType_AccountDetailId",
                table: "ContactType",
                column: "AccountDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomersId",
                table: "AspNetUsers",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetail_AccountDetailId",
                table: "AccountDetail",
                column: "AccountDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDetail_AccountDetail_AccountDetailId",
                table: "AccountDetail",
                column: "AccountDetailId",
                principalTable: "AccountDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomersId",
                table: "AspNetUsers",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactType_AccountDetail_AccountDetailId",
                table: "ContactType",
                column: "AccountDetailId",
                principalTable: "AccountDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AccountDetail_AccountDetailId",
                table: "Customers",
                column: "AccountDetailId",
                principalTable: "AccountDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ContactType_ContactTypeId",
                table: "Customers",
                column: "ContactTypeId",
                principalTable: "ContactType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentsId",
                table: "Orders",
                column: "PaymentsId",
                principalTable: "Payments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDetail_AccountDetail_AccountDetailId",
                table: "AccountDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomersId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactType_AccountDetail_AccountDetailId",
                table: "ContactType");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AccountDetail_AccountDetailId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ContactType_ContactTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountDetailId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ContactTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_ContactType_AccountDetailId",
                table: "ContactType");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomersId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AccountDetail_AccountDetailId",
                table: "AccountDetail");

            migrationBuilder.DropColumn(
                name: "PaymentsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountDetailId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountDetailId",
                table: "ContactType");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccountDetailId",
                table: "AccountDetail");
        }
    }
}
