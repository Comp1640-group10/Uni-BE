using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_BackEnd_API.Migrations
{
    /// <inheritdoc />
    public partial class addViewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ideaId",
                table: "Ideas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    visitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    ideaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.id);
                    table.ForeignKey(
                        name: "FK_Views_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ideaId",
                table: "Ideas",
                column: "ideaId");

            migrationBuilder.CreateIndex(
                name: "IX_Views_userId",
                table: "Views",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Views_ideaId",
                table: "Ideas",
                column: "ideaId",
                principalTable: "Views",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Views_ideaId",
                table: "Ideas");

            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_ideaId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "ideaId",
                table: "Ideas");
        }
    }
}
