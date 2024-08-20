using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShopWeb.Persistence.Migrations
{
    public partial class Mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountDetailId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ContactTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomersId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccountDetailId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AccountDetailId",
                table: "ContactType",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactType_AccountDetailId",
                table: "ContactType",
                newName: "IX_ContactType_CustomersId");

            migrationBuilder.RenameColumn(
                name: "AccountDetailId",
                table: "AccountDetail",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountDetail_AccountDetailId",
                table: "AccountDetail",
                newName: "IX_AccountDetail_CustomersId");

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomersId",
                table: "Orders",
                column: "CustomersId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserID",
                table: "Customers",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDetail_Customers_CustomersId",
                table: "AccountDetail",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactType_Customers_CustomersId",
                table: "ContactType",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserID",
                table: "Customers",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomersId",
                table: "Orders",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDetail_Customers_CustomersId",
                table: "AccountDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactType_Customers_CustomersId",
                table: "ContactType");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_AppUserID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomersId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomersId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AppUserID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomersId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "ContactType",
                newName: "AccountDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactType_CustomersId",
                table: "ContactType",
                newName: "IX_ContactType_AccountDetailId");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "AccountDetail",
                newName: "AccountDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountDetail_CustomersId",
                table: "AccountDetail",
                newName: "IX_AccountDetail_AccountDetailId");

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

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CustomersId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountDetailId",
                table: "Customers",
                column: "AccountDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactTypeId",
                table: "Customers",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomersId",
                table: "AspNetUsers",
                column: "CustomersId");

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
        }
    }
}
