using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Repository.Migrations
{
    public partial class UpdateRelationsProductInShoppingCardANDINOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrder_Products_OrderId",
                table: "ProductInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrder_Order_ProductId",
                table: "ProductInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCards_ProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrder_Order_OrderId",
                table: "ProductInOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrder_Products_ProductId",
                table: "ProductInOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ProductId",
                table: "ProductInShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCards_ShoppingCartId",
                table: "ProductInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrder_Order_OrderId",
                table: "ProductInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInOrder_Products_ProductId",
                table: "ProductInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCards_ShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrder_Products_OrderId",
                table: "ProductInOrder",
                column: "OrderId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInOrder_Order_ProductId",
                table: "ProductInOrder",
                column: "ProductId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCards_ProductId",
                table: "ProductInShoppingCarts",
                column: "ProductId",
                principalTable: "ShoppingCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ShoppingCartId",
                table: "ProductInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
