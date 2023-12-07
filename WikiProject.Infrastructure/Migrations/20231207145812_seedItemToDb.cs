using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WikiProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedItemToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreateDate", "Description", "ImageUrl", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "Does something something.", "https://placehold.co/600x400", "Placeholder1", null },
                    { 2, null, "Does something something.", "https://placehold.co/600x401", "Placeholder2", null },
                    { 3, null, "Does something something.", "https://placehold.co/600x402", "Placeholder3", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
