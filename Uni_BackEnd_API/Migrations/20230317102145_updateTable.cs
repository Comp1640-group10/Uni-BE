using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_BackEnd_API.Migrations
{
    /// <inheritdoc />
    public partial class updateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Comments_ideaId",
                table: "Ideas");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ideaId",
                table: "Comments",
                column: "ideaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ideas_ideaId",
                table: "Comments",
                column: "ideaId",
                principalTable: "Ideas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ideas_ideaId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ideaId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Comments_ideaId",
                table: "Ideas",
                column: "ideaId",
                principalTable: "Comments",
                principalColumn: "id");
        }
    }
}
