using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyPOS.Backoffice.Migrations
{
    /// <inheritdoc />
    public partial class RenameNicknamewithGUID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NickName",
                table: "TablesOrSeats");

            migrationBuilder.AddColumn<string>(
                name: "GUID",
                table: "TablesOrSeats",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GUID",
                table: "TablesOrSeats");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "TablesOrSeats",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
