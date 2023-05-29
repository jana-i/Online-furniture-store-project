using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Repository.Migrations
{
    public partial class UpdateEmailMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Satatus",
                table: "EmailMessages");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "EmailMessages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EmailMessages");

            migrationBuilder.AddColumn<bool>(
                name: "Satatus",
                table: "EmailMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
