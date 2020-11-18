using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class ustvarjene_povezave_s_statusi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Partys_PartyStatusId",
                table: "Partys",
                column: "PartyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Partys_UserId",
                table: "Partys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendshipStatusId",
                table: "Friendships",
                column: "FriendshipStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationStatusId",
                table: "Applications",
                column: "ApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PartyId",
                table: "Applications",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationStatuses_ApplicationStatusId",
                table: "Applications",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Partys_PartyId",
                table: "Applications",
                column: "PartyId",
                principalTable: "Partys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_FriendshipStatuses_FriendshipStatusId",
                table: "Friendships",
                column: "FriendshipStatusId",
                principalTable: "FriendshipStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partys_PartyStatuses_PartyStatusId",
                table: "Partys",
                column: "PartyStatusId",
                principalTable: "PartyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partys_Users_UserId",
                table: "Partys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationStatuses_ApplicationStatusId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Partys_PartyId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_FriendshipStatuses_FriendshipStatusId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Partys_PartyStatuses_PartyStatusId",
                table: "Partys");

            migrationBuilder.DropForeignKey(
                name: "FK_Partys_Users_UserId",
                table: "Partys");

            migrationBuilder.DropIndex(
                name: "IX_Partys_PartyStatusId",
                table: "Partys");

            migrationBuilder.DropIndex(
                name: "IX_Partys_UserId",
                table: "Partys");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_FriendshipStatusId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationStatusId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_PartyId",
                table: "Applications");
        }
    }
}
