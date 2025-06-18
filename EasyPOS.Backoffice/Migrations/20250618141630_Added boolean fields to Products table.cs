using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyPOS.Backoffice.Migrations
{
    /// <inheritdoc />
    public partial class AddedbooleanfieldstoProductstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Bucket",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hide",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Promotion",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bucket",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Hide",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Promotion",
                table: "Products");
        }
    }
}
