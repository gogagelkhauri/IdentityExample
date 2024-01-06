using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class changebalanceUserIsrequiredFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBalance_User_UserId",
                table: "UserBalance");

            migrationBuilder.DropIndex(
                name: "IX_UserBalance_UserId",
                table: "UserBalance");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBalance",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_UserBalance_UserId",
                table: "UserBalance",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBalance_User_UserId",
                table: "UserBalance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBalance_User_UserId",
                table: "UserBalance");

            migrationBuilder.DropIndex(
                name: "IX_UserBalance_UserId",
                table: "UserBalance");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBalance",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBalance_UserId",
                table: "UserBalance",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBalance_User_UserId",
                table: "UserBalance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
