using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class CatalogDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brand_Images_ImageId",
                table: "brand");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_Images_ImageId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Images_ThumbnailId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_brand_BrandId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ThumbnailId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_categories_ImageId",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brand",
                table: "brand");

            migrationBuilder.DropIndex(
                name: "IX_brand_ImageId",
                table: "brand");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "brand");

            migrationBuilder.RenameTable(
                name: "brand",
                newName: "brands");

            migrationBuilder.AlterColumn<int>(
                name: "ThumbnailId",
                table: "products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "brands",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brands",
                table: "brands",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_products_ThumbnailId",
                table: "products",
                column: "ThumbnailId",
                unique: true,
                filter: "[ThumbnailId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_categories_ImageId",
                table: "categories",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_brands_ImageId",
                table: "brands",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_brands_Images_ImageId",
                table: "brands",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_categories_Images_ImageId",
                table: "categories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Images_ThumbnailId",
                table: "products",
                column: "ThumbnailId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brands_Images_ImageId",
                table: "brands");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_Images_ImageId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Images_ThumbnailId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_brands_BrandId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ThumbnailId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_categories_ImageId",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brands",
                table: "brands");

            migrationBuilder.DropIndex(
                name: "IX_brands_ImageId",
                table: "brands");

            migrationBuilder.RenameTable(
                name: "brands",
                newName: "brand");

            migrationBuilder.AlterColumn<int>(
                name: "ThumbnailId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "brand",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brand",
                table: "brand",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_products_ThumbnailId",
                table: "products",
                column: "ThumbnailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_ImageId",
                table: "categories",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_brand_ImageId",
                table: "brand",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_brand_Images_ImageId",
                table: "brand",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_Images_ImageId",
                table: "categories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Images_ThumbnailId",
                table: "products",
                column: "ThumbnailId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_brand_BrandId",
                table: "products",
                column: "BrandId",
                principalTable: "brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
