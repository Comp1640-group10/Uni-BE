using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_BackEnd_API.Migrations
{
    /// <inheritdoc />
    public partial class addRactAndCommentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    ideaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reacts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    react = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    ideaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reacts_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Reacts_userId",
                table: "Reacts",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Comments_ideaId",
                table: "Ideas",
                column: "ideaId",
                principalTable: "Comments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Reacts_ideaId",
                table: "Ideas",
                column: "ideaId",
                principalTable: "Reacts",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Comments_ideaId",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Reacts_ideaId",
                table: "Ideas");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reacts");
        }
    }
}
