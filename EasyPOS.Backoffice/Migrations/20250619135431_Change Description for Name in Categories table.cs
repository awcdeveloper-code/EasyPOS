using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyPOS.Backoffice.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDescriptionforNameinCategoriestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "Description");
        }
    }
}
