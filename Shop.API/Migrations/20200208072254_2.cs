using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.API.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductLinks");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductLinks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductLinks");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductLinks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
