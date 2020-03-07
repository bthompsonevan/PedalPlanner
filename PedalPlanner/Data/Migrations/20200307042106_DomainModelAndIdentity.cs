using Microsoft.EntityFrameworkCore.Migrations;

namespace PedalPlanner.Data.Migrations
{
    public partial class DomainModelAndIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedal",
                columns: table => new
                {
                    PedalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedalName = table.Column<string>(nullable: true),
                    PedalType = table.Column<string>(nullable: true),
                    PedalSubType = table.Column<string>(nullable: true),
                    PedalColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedal", x => x.PedalID);
                });

            migrationBuilder.CreateTable(
                name: "Rig",
                columns: table => new
                {
                    RigID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instrument = table.Column<string>(nullable: true),
                    BoardSize = table.Column<int>(nullable: false),
                    PedalID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rig", x => x.RigID);
                    table.ForeignKey(
                        name: "FK_Rig_Pedal_PedalID",
                        column: x => x.PedalID,
                        principalTable: "Pedal",
                        principalColumn: "PedalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rig_PedalID",
                table: "Rig",
                column: "PedalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rig");

            migrationBuilder.DropTable(
                name: "Pedal");
        }
    }
}
