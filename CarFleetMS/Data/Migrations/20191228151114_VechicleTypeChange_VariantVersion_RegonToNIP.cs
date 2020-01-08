using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class VechicleTypeChange_VariantVersion_RegonToNIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "VehicleType",
                newName: "Version");

            migrationBuilder.AddColumn<string>(
                name: "Variant",
                table: "VehicleType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Variant",
                table: "VehicleType");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "VehicleType",
                newName: "Name");
        }
    }
}
