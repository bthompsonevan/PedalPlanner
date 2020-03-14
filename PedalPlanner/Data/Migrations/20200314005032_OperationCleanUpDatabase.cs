using Microsoft.EntityFrameworkCore.Migrations;

namespace PedalPlanner.Data.Migrations
{
    public partial class OperationCleanUpDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedal_AspNetUsers_identityUserId",
                table: "Pedal");

            migrationBuilder.DropForeignKey(
                name: "FK_Rig_AspNetUsers_identityUserId",
                table: "Rig");

            migrationBuilder.DropIndex(
                name: "IX_Rig_identityUserId",
                table: "Rig");

            migrationBuilder.DropIndex(
                name: "IX_Pedal_identityUserId",
                table: "Pedal");

            migrationBuilder.DropColumn(
                name: "identityUserId",
                table: "Rig");

            migrationBuilder.DropColumn(
                name: "identityUserId",
                table: "Pedal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identityUserId",
                table: "Rig",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "identityUserId",
                table: "Pedal",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rig_identityUserId",
                table: "Rig",
                column: "identityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedal_identityUserId",
                table: "Pedal",
                column: "identityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedal_AspNetUsers_identityUserId",
                table: "Pedal",
                column: "identityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rig_AspNetUsers_identityUserId",
                table: "Rig",
                column: "identityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
