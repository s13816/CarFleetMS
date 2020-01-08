using Microsoft.EntityFrameworkCore.Migrations;

namespace CarFleetMS.Data.Migrations
{
    public partial class VehicleChangesTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
