using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopBridge.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIdColumnNameInProductsCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsCategories_Categories_CategoryIdName",
                table: "ProductsCategories");

            migrationBuilder.RenameColumn(
                name: "CategoryIdName",
                table: "ProductsCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsCategories_CategoryIdName",
                table: "ProductsCategories",
                newName: "IX_ProductsCategories_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsCategories_Categories_CategoryId",
                table: "ProductsCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsCategories_Categories_CategoryId",
                table: "ProductsCategories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductsCategories",
                newName: "CategoryIdName");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories",
                newName: "IX_ProductsCategories_CategoryIdName");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsCategories_Categories_CategoryIdName",
                table: "ProductsCategories",
                column: "CategoryIdName",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
