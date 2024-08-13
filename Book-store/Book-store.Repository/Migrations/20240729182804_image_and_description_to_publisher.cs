using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_store.Repository.Migrations
{
    /// <inheritdoc />
    public partial class image_and_description_to_publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookImage",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookImage",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Publishers");
        }
    }
}
