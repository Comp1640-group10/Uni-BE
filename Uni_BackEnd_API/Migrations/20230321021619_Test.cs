using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_BackEnd_API.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ideas_ideaId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ideas_ideaId",
                table: "Comments",
                column: "ideaId",
                principalTable: "Ideas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ideas_ideaId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ideas_ideaId",
                table: "Comments",
                column: "ideaId",
                principalTable: "Ideas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
