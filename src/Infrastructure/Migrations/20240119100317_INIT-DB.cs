using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class INITDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AIRPORTS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    COUNTRY = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRPORTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESET_PASSWORD",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EXPIRED_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESET_PASSWORD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
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
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FLIGHTS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    LOADING_ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    UNLOADING_ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DATE_TIME = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLIGHTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPORTS_LOADING_ID",
                        column: x => x.LOADING_ID,
                        principalTable: "AIRPORTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPORTS_UNLOADING_ID",
                        column: x => x.UNLOADING_ID,
                        principalTable: "AIRPORTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ROLE_PERMISSION",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VALUE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ROLE_ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_PERMISSION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ROLE_PERMISSION_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    USER_ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    ROLE_ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_ROLES_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USER_ROLE_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DOCUMENTS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VERSION = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FLIGHT_ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DOCUMENTS_FLIGHTS_FLIGHT_ID",
                        column: x => x.FLIGHT_ID,
                        principalTable: "FLIGHTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENTS_FLIGHT_ID",
                table: "DOCUMENTS",
                column: "FLIGHT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_LOADING_ID",
                table: "FLIGHTS",
                column: "LOADING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_UNLOADING_ID",
                table: "FLIGHTS",
                column: "UNLOADING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_PERMISSION_ROLE_ID",
                table: "ROLE_PERMISSION",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_ROLE_ID",
                table: "USER_ROLE",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_USER_ID",
                table: "USER_ROLE",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOCUMENTS");

            migrationBuilder.DropTable(
                name: "RESET_PASSWORD");

            migrationBuilder.DropTable(
                name: "ROLE_PERMISSION");

            migrationBuilder.DropTable(
                name: "USER_ROLE");

            migrationBuilder.DropTable(
                name: "FLIGHTS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "AIRPORTS");
        }
    }
}
