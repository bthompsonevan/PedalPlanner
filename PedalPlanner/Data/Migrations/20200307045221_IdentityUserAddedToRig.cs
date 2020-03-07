using Microsoft.EntityFrameworkCore.Migrations;

namespace PedalPlanner.Data.Migrations
{
    public partial class IdentityUserAddedToRig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identityUserId",
                table: "Rig",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rig_identityUserId",
                table: "Rig",
                column: "identityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rig_AspNetUsers_identityUserId",
                table: "Rig",
                column: "identityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rig_AspNetUsers_identityUserId",
                table: "Rig");

            migrationBuilder.DropIndex(
                name: "IX_Rig_identityUserId",
                table: "Rig");

            migrationBuilder.DropColumn(
                name: "identityUserId",
                table: "Rig");
        }
    }
}
