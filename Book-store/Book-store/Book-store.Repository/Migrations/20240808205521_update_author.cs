using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_store.Repository.Migrations
{
    /// <inheritdoc />
    public partial class update_author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Authors");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Authors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
