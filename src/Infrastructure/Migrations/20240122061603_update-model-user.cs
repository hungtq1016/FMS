using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updatemodeluser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NAME",
                table: "DOCUMENTS");

            migrationBuilder.RenameColumn(
                name: "DESCRIPTION",
                table: "ROLES",
                newName: "NOTE");

            migrationBuilder.RenameColumn(
                name: "VERSION",
                table: "DOCUMENTS",
                newName: "EXTENSION");

            migrationBuilder.AddColumn<string>(
                name: "IMAGE_ID",
                table: "USERS",
                type: "varchar(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DEPARTURE_DATE",
                table: "FLIGHTS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ROUTE",
                table: "FLIGHTS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ALT",
                table: "DOCUMENTS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PATH",
                table: "DOCUMENTS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "SIZE",
                table: "DOCUMENTS",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "TITLE",
                table: "DOCUMENTS",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SHORT_NAME",
                table: "AIRPORTS",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DOCUMENT_VERSIONS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    VERSION_NUMBER = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DOCUMENT_ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENT_VERSIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DOCUMENT_VERSIONS_DOCUMENTS_DOCUMENT_ID",
                        column: x => x.DOCUMENT_ID,
                        principalTable: "DOCUMENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    ENABLE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ALT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIZE = table.Column<long>(type: "bigint", nullable: false),
                    PATH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EXTENSION = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_IMAGE_ID",
                table: "USERS",
                column: "IMAGE_ID",
                unique: true,
                filter: "[IMAGE_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENT_VERSIONS_DOCUMENT_ID",
                table: "DOCUMENT_VERSIONS",
                column: "DOCUMENT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_Image_IMAGE_ID",
                table: "USERS",
                column: "IMAGE_ID",
                principalTable: "Image",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_Image_IMAGE_ID",
                table: "USERS");

            migrationBuilder.DropTable(
                name: "DOCUMENT_VERSIONS");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_USERS_IMAGE_ID",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "IMAGE_ID",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "DEPARTURE_DATE",
                table: "FLIGHTS");

            migrationBuilder.DropColumn(
                name: "ROUTE",
                table: "FLIGHTS");

            migrationBuilder.DropColumn(
                name: "ALT",
                table: "DOCUMENTS");

            migrationBuilder.DropColumn(
                name: "PATH",
                table: "DOCUMENTS");

            migrationBuilder.DropColumn(
                name: "SIZE",
                table: "DOCUMENTS");

            migrationBuilder.DropColumn(
                name: "TITLE",
                table: "DOCUMENTS");

            migrationBuilder.DropColumn(
                name: "SHORT_NAME",
                table: "AIRPORTS");

            migrationBuilder.RenameColumn(
                name: "NOTE",
                table: "ROLES",
                newName: "DESCRIPTION");

            migrationBuilder.RenameColumn(
                name: "EXTENSION",
                table: "DOCUMENTS",
                newName: "VERSION");

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "DOCUMENTS",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
