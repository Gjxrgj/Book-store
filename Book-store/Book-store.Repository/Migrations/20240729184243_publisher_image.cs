using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_store.Repository.Migrations
{
    /// <inheritdoc />
    public partial class publisher_image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookImage",
                table: "Publishers",
                newName: "PublisherImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublisherImage",
                table: "Publishers",
                newName: "BookImage");
        }
    }
}
