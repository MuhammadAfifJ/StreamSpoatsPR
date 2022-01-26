using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StreamSpoatsPR.Server.Data.Migrations
{
    public partial class p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    ItemSerial = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.ItemSerial);
                    table.ForeignKey(
                        name: "FK_Purchase_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Review",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSerial = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportName = table.Column<int>(type: "int", nullable: false),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandName",
                        column: x => x.BrandName,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Purchase_ItemSerial",
                        column: x => x.ItemSerial,
                        principalTable: "Purchase",
                        principalColumn: "ItemSerial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sport_SportName",
                        column: x => x.SportName,
                        principalTable: "Sport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Types_ItemType",
                        column: x => x.ItemType,
                        principalTable: "Types",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandName",
                table: "Products",
                column: "BrandName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemSerial",
                table: "Products",
                column: "ItemSerial");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemType",
                table: "Products",
                column: "ItemType");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SportName",
                table: "Products",
                column: "SportName");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ReviewId",
                table: "Purchase",
                column: "ReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
