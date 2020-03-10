using Microsoft.EntityFrameworkCore.Migrations;

namespace PedalPlanner.Data.Migrations
{
    public partial class addedidentyusertopedal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identityUserId",
                table: "Pedal",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedal_AspNetUsers_identityUserId",
                table: "Pedal");

            migrationBuilder.DropIndex(
                name: "IX_Pedal_identityUserId",
                table: "Pedal");

            migrationBuilder.DropColumn(
                name: "identityUserId",
                table: "Pedal");
        }
    }
}
