using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Preimenoval_Atribute_Za_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PartyStatus",
                table: "Parties",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "FriendshipStatus",
                table: "Friendships",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ApplicationStatus",
                table: "Applications",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Parties",
                newName: "PartyStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Friendships",
                newName: "FriendshipStatus");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Applications",
                newName: "ApplicationStatus");
        }
    }
}
