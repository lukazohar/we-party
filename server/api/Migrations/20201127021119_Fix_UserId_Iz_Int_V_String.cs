using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Fix_UserId_Iz_Int_V_String : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId1",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_AspNetUsers_UserId1",
                table: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Parties_UserId1",
                table: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Parties",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_UserId",
                table: "Parties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_AspNetUsers_UserId",
                table: "Parties",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_AspNetUsers_UserId",
                table: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Parties_UserId",
                table: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserId",
                table: "Applications");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Parties",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Parties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parties_UserId1",
                table: "Parties",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId1",
                table: "Applications",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId1",
                table: "Applications",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_AspNetUsers_UserId1",
                table: "Parties",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
