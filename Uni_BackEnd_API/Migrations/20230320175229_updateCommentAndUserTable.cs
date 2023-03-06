using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_BackEnd_API.Migrations
{
    /// <inheritdoc />
    public partial class updateCommentAndUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_departmentId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "departmentId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_departmentId",
                table: "Users",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_departmentId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "departmentId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_departmentId",
                table: "Users",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
