using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class InstitutioFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_InstitutionId",
                table: "Vehicle",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "VehicleInstitution",
                table: "Vehicle",
                column: "InstitutionId",
                principalTable: "Institution",
                principalColumn: "InstitutionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "VehicleInstitution",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_InstitutionId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "Vehicle");
        }
    }
}
