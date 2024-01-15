using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class init_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HEX_CODE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    FULL_NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    USER_NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    REFRESH_TOKEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    REFRESH_TOKEN_EXPIRED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STATUS_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STATUS_ID1 = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_STATUS_ID1",
                        column: x => x.STATUS_ID1,
                        principalTable: "Statuses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_STATUS_ID1",
                table: "Users",
                column: "STATUS_ID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
