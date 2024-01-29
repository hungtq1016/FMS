using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.OAuth2.Data.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "$2a$11$Q.qFnpUQvnt7WwzqU6.0qOTgYooT4Gdu6Szrvl3pGAE0jBYm20tUS",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "$2a$11$Q.qFnpUQvnt7WwzqU6.0qOTgYooT4Gdu6Szrvl3pGAE0jBYm20tUS");
        }
    }
}
