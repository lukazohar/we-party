using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Odstranjene_Tabele_Za_Statuse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationStatuses_ApplicationStatusId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_FriendshipStatuses_FriendshipStatusId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_PartyStatuses_PartyStatusId",
                table: "Parties");

            migrationBuilder.DropTable(
                name: "ApplicationStatuses");

            migrationBuilder.DropTable(
                name: "FriendshipStatuses");

            migrationBuilder.DropTable(
                name: "PartyStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Parties_PartyStatusId",
                table: "Parties");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_FriendshipStatusId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationStatusId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PartyStatusId",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "FriendshipStatusId",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusId",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "PartyStatus",
                table: "Parties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FriendshipStatus",
                table: "Friendships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartyStatus",
                table: "Parties");

            migrationBuilder.DropColumn(
                name: "FriendshipStatus",
                table: "Friendships");

            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "PartyStatusId",
                table: "Parties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FriendshipStatusId",
                table: "Friendships",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatusId",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendshipStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartyStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parties_PartyStatusId",
                table: "Parties",
                column: "PartyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FriendshipStatusId",
                table: "Friendships",
                column: "FriendshipStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationStatusId",
                table: "Applications",
                column: "ApplicationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationStatuses_ApplicationStatusId",
                table: "Applications",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_FriendshipStatuses_FriendshipStatusId",
                table: "Friendships",
                column: "FriendshipStatusId",
                principalTable: "FriendshipStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_PartyStatuses_PartyStatusId",
                table: "Parties",
                column: "PartyStatusId",
                principalTable: "PartyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
