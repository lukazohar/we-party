using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Partys_PartyId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Partys_PartyStatuses_PartyStatusId",
                table: "Partys");

            migrationBuilder.DropForeignKey(
                name: "FK_Partys_Users_UserId",
                table: "Partys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partys",
                table: "Partys");

            migrationBuilder.RenameTable(
                name: "Partys",
                newName: "Parties");

            migrationBuilder.RenameIndex(
                name: "IX_Partys_UserId",
                table: "Parties",
                newName: "IX_Parties_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Partys_PartyStatusId",
                table: "Parties",
                newName: "IX_Parties_PartyStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parties",
                table: "Parties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Parties_PartyId",
                table: "Applications",
                column: "PartyId",
                principalTable: "Parties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_PartyStatuses_PartyStatusId",
                table: "Parties",
                column: "PartyStatusId",
                principalTable: "PartyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Users_UserId",
                table: "Parties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Parties_PartyId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_PartyStatuses_PartyStatusId",
                table: "Parties");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Users_UserId",
                table: "Parties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parties",
                table: "Parties");

            migrationBuilder.RenameTable(
                name: "Parties",
                newName: "Partys");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_UserId",
                table: "Partys",
                newName: "IX_Partys_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_PartyStatusId",
                table: "Partys",
                newName: "IX_Partys_PartyStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partys",
                table: "Partys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Partys_PartyId",
                table: "Applications",
                column: "PartyId",
                principalTable: "Partys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partys_PartyStatuses_PartyStatusId",
                table: "Partys",
                column: "PartyStatusId",
                principalTable: "PartyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partys_Users_UserId",
                table: "Partys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
