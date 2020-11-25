using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Friendship_Removed_ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_AspNetUsers_ReceiverId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_AspNetUsers_RequesterId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_ReceiverId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_RequesterId",
                table: "Friendships");

            migrationBuilder.AlterColumn<string>(
                name: "RequesterId",
                table: "Friendships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Friendships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequesterId",
                table: "Friendships",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Friendships",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_ReceiverId",
                table: "Friendships",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_RequesterId",
                table: "Friendships",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_AspNetUsers_ReceiverId",
                table: "Friendships",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_AspNetUsers_RequesterId",
                table: "Friendships",
                column: "RequesterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
