using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class DropPurposeCreateCehicleKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleKindId",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleKind",
                columns: table => new
                {
                    VehicleKindId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleKind", x => x.VehicleKindId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleKindId",
                table: "Vehicle",
                column: "VehicleKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleKind_VehicleKindId",
                table: "Vehicle",
                column: "VehicleKindId",
                principalTable: "VehicleKind",
                principalColumn: "VehicleKindId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleKind_VehicleKindId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleKind");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_VehicleKindId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleKindId",
                table: "Vehicle");
        }
    }
}
