using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_BackEnd_API.Migrations
{
    /// <inheritdoc />
    public partial class updateReactAndViewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Reacts_ideaId",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_Views_ideaId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_ideaId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "ideaId",
                table: "Ideas");

            migrationBuilder.CreateIndex(
                name: "IX_Views_ideaId",
                table: "Views",
                column: "ideaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reacts_ideaId",
                table: "Reacts",
                column: "ideaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reacts_Ideas_ideaId",
                table: "Reacts",
                column: "ideaId",
                principalTable: "Ideas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Views_Ideas_ideaId",
                table: "Views",
                column: "ideaId",
                principalTable: "Ideas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reacts_Ideas_ideaId",
                table: "Reacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Views_Ideas_ideaId",
                table: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Views_ideaId",
                table: "Views");

            migrationBuilder.DropIndex(
                name: "IX_Reacts_ideaId",
                table: "Reacts");

            migrationBuilder.AddColumn<int>(
                name: "ideaId",
                table: "Ideas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ideaId",
                table: "Ideas",
                column: "ideaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Reacts_ideaId",
                table: "Ideas",
                column: "ideaId",
                principalTable: "Reacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_Views_ideaId",
                table: "Ideas",
                column: "ideaId",
                principalTable: "Views",
                principalColumn: "id");
        }
    }
}
