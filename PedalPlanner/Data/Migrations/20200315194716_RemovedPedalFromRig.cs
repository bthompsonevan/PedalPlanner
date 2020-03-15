using Microsoft.EntityFrameworkCore.Migrations;

namespace PedalPlanner.Data.Migrations
{
    public partial class RemovedPedalFromRig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rig_Pedal_PedalID",
                table: "Rig");

            migrationBuilder.DropIndex(
                name: "IX_Rig_PedalID",
                table: "Rig");

            migrationBuilder.DropColumn(
                name: "PedalID",
                table: "Rig");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedalID",
                table: "Rig",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rig_PedalID",
                table: "Rig",
                column: "PedalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rig_Pedal_PedalID",
                table: "Rig",
                column: "PedalID",
                principalTable: "Pedal",
                principalColumn: "PedalID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
