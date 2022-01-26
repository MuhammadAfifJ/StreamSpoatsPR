using Microsoft.EntityFrameworkCore.Migrations;

namespace StreamSpoatsPR.Server.Data.Migrations
{
    public partial class purchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchase_ItemSerial",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Review_ReviewId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Purchases");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_ReviewId",
                table: "Purchases",
                newName: "IX_Purchases_ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "ItemSerial");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Purchases_ItemSerial",
                table: "Products",
                column: "ItemSerial",
                principalTable: "Purchases",
                principalColumn: "ItemSerial",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Reviews_ReviewId",
                table: "Purchases",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchases_ItemSerial",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Reviews_ReviewId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Purchase");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_ReviewId",
                table: "Purchase",
                newName: "IX_Purchase_ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "ItemSerial");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Purchase_ItemSerial",
                table: "Products",
                column: "ItemSerial",
                principalTable: "Purchase",
                principalColumn: "ItemSerial",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Review_ReviewId",
                table: "Purchase",
                column: "ReviewId",
                principalTable: "Review",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
