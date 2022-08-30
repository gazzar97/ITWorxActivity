using Microsoft.EntityFrameworkCore.Migrations;

namespace ITWorxActivity.Entities.Migrations
{
    public partial class seedProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "ImageURL", "Name", "Price", "Qunatity" },
                values: new object[] { 1, 1, null, "Apple", 5.0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);
        }
    }
}
