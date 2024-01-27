using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.OAuth2.Data.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "Assignments",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "Assignments");
        }
    }
}
